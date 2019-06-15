using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TRHDipComp_Project.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "";

        public void OnGet()
        {       

            if (Request.Cookies["Student_Results_Management_Project"] !=null)
            {
                Message = "Welcome back!\n " + Request.Cookies["Student_Results_Management_Project"];
            }
            else
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddYears(1);

                string currentDate = DateTime.Now.ToString();
                Response.Cookies.Append("Student_Results_Management_Project", 
                                        "\nYour last visit was " + currentDate, 
                                        options);

                Message = "Welcome! \n";
            }
        }
    }
}
