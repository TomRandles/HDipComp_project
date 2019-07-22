using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TRHDipComp_Project;

namespace TRHDipComp_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string Message { get; set; } = "";

        [BindProperty]
        public string OpenWeatherMapsCityID { get; private set; }

        [BindProperty]
        public string GoogleMapsLatitudeCoordinate { get; private set; }

        [BindProperty]
        public string GoogleMapsLongitudeCoordinate { get; private set; }


        private readonly CookieOptions options = new CookieOptions();

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            // Cookies code
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            options.Expires = DateTime.Now.AddYears(1);

            if (Request.Cookies["Student_Results_Management_Project"] != null)
            {
                Message = "Welcome back! " + Request.Cookies["Student_Results_Management_Project"];
                Response.Cookies.Append("Student_Results_Management_Project",
                                        "Your last visit was " + currentDate,
                                        options);
            }
            else
            {
                Response.Cookies.Append("Student_Results_Management_Project",
                                        " Your last visit was " + currentDate,
                                        options);

                Message = "Welcome! ";
            }

            // Get OpenWeatherMaps City ID configuration value 
            OpenWeatherMapsCityID = _configuration["AppSettings:OpenWeatherMapCityID"];

            // Get Google Maps co-ordinates as configured
            GoogleMapsLatitudeCoordinate = _configuration["AppSettings:GoogleMapsLatitudeCoordinate"];
            GoogleMapsLongitudeCoordinate = _configuration["AppSettings:GoogleMapsLongitudeCoordinate"];
        }
    }
}
