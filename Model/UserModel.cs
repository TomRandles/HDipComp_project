using System.ComponentModel.DataAnnotations;

namespace TRHDipComp_Project.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string EmailAddress { get; set; }
    }
}