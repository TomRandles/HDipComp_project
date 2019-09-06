using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TRHDipComp_Project.Areas.StudentPages.Pages 
{
    public class SendStudentMessageResultsModel : PageModel
    {
        [TempData]
        public string MessageResults { get; set; } 

        public void OnGet()
        {

        }
    }
}