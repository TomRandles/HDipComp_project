using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TRHDipComp_Project.Areas.ErrorPages.Pages
{
    public class MyErrorPageModel : PageModel
    {

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet()
        {

        }
    }
}