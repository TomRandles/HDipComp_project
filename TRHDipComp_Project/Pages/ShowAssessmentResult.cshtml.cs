using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class ShowAssessmentResultModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public ShowAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AssessmentResult AssessmentResult { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            AssessmentResult = await _db.AssessmentResults.FindAsync(id);

            if (AssessmentResult == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var assess = await _db.Assessments.FindAsync(AssessmentResult.AssessmentResultID);

            if (assess != null)
            {
                _db.Assessments.Remove(assess);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}