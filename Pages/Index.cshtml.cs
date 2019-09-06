using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace TRHDipComp_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;


        #region properties
        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public string CookieMessage { get; set; }

        [BindProperty]
        public string OpenWeatherMapAPIKey { get; private set; }

        [BindProperty]
        public string GoogleMapsAPIKey { get; private set; }

        [BindProperty]
        public string OpenWeatherMapsCityID { get; private set; }

        [BindProperty]
        public string GoogleMapsLatitudeCoordinate { get; private set; }

        [BindProperty]
        public string GoogleMapsLongitudeCoordinate { get; private set; }

        #endregion

        private readonly CookieOptions options = new CookieOptions();

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult OnGet()
        {
            #region cookies_code
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            options.Expires = DateTime.Now.AddYears(1);

            if (Request.Cookies["Student_Results_Management_Project"] != null)
            {
                CookieMessage = "Welcome back! " + Request.Cookies["Student_Results_Management_Project"];
                Response.Cookies.Append("Student_Results_Management_Project",
                                        "Your last visit was " + currentDate,
                                        options);
            }
            else
            {
                Response.Cookies.Append("Student_Results_Management_Project",
                                        " Your last visit was " + currentDate,
                                        options);

                CookieMessage = "Welcome! ";
            }
            #endregion

            #region setup_configurations
            OpenWeatherMapAPIKey = _configuration["AppSettings:OpenWeatherMapAPIKey"];

            GoogleMapsAPIKey = _configuration["AppSettings:GoogleMapsAPIKey"];

            // Get OpenWeatherMaps City ID configuration value 
            OpenWeatherMapsCityID = _configuration["AppSettings:OpenWeatherMapCityID"];

            // Get Google Maps co-ordinates as configured
            GoogleMapsLatitudeCoordinate = _configuration["AppSettings:GoogleMapsLatitudeCoordinate"];
            GoogleMapsLongitudeCoordinate = _configuration["AppSettings:GoogleMapsLongitudeCoordinate"];

            string SENDGRID_API_KEY = _configuration["AppSettings:SENDGRID_API_KEY"];

            if (!String.IsNullOrEmpty(SENDGRID_API_KEY))
            {
                Environment.SetEnvironmentVariable("SENDGRID_API_KEY", SENDGRID_API_KEY);
            }
            else
            {
                ErrorMessage = "SENDGRID_API_KEY is not configured in the application";
                return RedirectToPage("Error");
            }

            #endregion

            return Page();
        }
    }
}
