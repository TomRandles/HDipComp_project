using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project;

namespace TRHDipComp_Project.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "";

        public string GoogleMapsCityID { get; private set; }

        private readonly CookieOptions options = new CookieOptions();

        public void OnGet()
        {

            string currentDate = DateTime.Now.ToString();
            options.Expires = DateTime.Now.AddYears(1);

            if (Request.Cookies["Student_Results_Management_Project"] !=null)
            {
                Message = "Welcome back!\n " + Request.Cookies["Student_Results_Management_Project"];
                Response.Cookies.Append("Student_Results_Management_Project",
                                        "\nYour last visit was " + currentDate,
                                        options);
            }
            else
            {
                      
                Response.Cookies.Append("Student_Results_Management_Project", 
                                        "\nYour last visit was " + currentDate, 
                                        options);

                Message = "Welcome! \n";
            }
        }
    }
}
