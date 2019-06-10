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
        public string Message { get; set; } = "Welcome";

        public void OnGet()
        {

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(1);
            

            Response.Cookies.Append("MyFirstCookie", "Hello there ...", options);

            if (Request.Cookies["MyFirstCookie"] !=null)
            {
                Message = "Welcome back" + Request.Cookies["MyFirstCookie"];
            }
            else
            {
                // string currentDate = DateTime.Now.ToString();
                Message += Request.Cookies["MyFirstCookie"];
            }
        }
    }
}
