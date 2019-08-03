using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Controllers
{
    public class AuthenticationController : Controller
    {
        private IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationController(IConfiguration config, UserManager<IdentityUser> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        // /login should suffice to access this function from the domain name
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody]UserModel registerDetails)
        {
            // Create and save student authentication
            IdentityUser user = new IdentityUser
            {
                UserName = registerDetails.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //  Create a user
            var result = await _userManager.CreateAsync(user, registerDetails.Password);
            if (result.Succeeded)
            {
                // Add new student to the Student role
                await _userManager.AddToRoleAsync(user, "Student");
            }
            return Ok(new { Username = registerDetails.Username });
        }

        // /login should suffice to access this function from the domain name
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserModel login)
        {
            // Check in the Authentication DB if this user is present
            var user = await _userManager.FindByNameAsync(login.Username);

            // Check if password is valid
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                // Instantiate the new claim, based on the user name
                var claim = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };

                //Generate a new signin key for this user - use configuration 
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]));

                // Get expiry minutes - how long this login session will last
                int expiryMinutes = Convert.ToInt32(_config["Jwt:ExpiryInMinutes"]);

                // Generate new Jwt token for this user, to be used in all of its interactions with the application
                var token = new JwtSecurityToken(
                                issuer: _config["Jwt:Site"],
                                audience: _config["Jwt:Site"],
                                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                            );
                return Ok(
                         new
                         {
                             token = new JwtSecurityTokenHandler().WriteToken(token),
                             expiration = token.ValidTo
                         }
                );
            }
            // User not authorised. Username and/or password invalid
            return Unauthorized();
        }
    }
}