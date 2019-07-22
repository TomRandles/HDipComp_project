using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class DeleteAssessmentModel : PageModel
    {
        private CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

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
            try
            {
                var assess = await _db.Assessments.FindAsync(Assessment.AssessmentID);

                if (assess != null)
                {
                    _db.Assessments.Remove(assess);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "Db Update Concurrency error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "Db Update error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
            }
            catch (Exception e)
            {
                ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
            }

            return RedirectToPage("/ListAssessments");
        }
    }
}