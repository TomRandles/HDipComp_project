using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class DeleteAssessmentModel : PageModel
    {
        private CollegeDbContext _db;

        public DeleteAssessmentModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Assessment Assessment { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Assessment = await _db.Assessments.FindAsync(id);

            if (Assessment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var assess = await _db.Assessments.FindAsync(Assessment.AssessmentID);

            if (assess != null)
            {
                _db.Assessments.Remove(assess);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("/ListAssessments");
        }
    }
}