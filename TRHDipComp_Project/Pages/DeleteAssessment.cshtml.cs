using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class DeleteAssessmentModel : PageModel
    {
        private readonly CollegeDbContext _db;

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
            // local copy of assessment ID
            string assessID = Assessment.AssessmentID;
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
                ErrorMessage = "DeleteAssessment: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteAssessment: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteAssessment: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessID });
            }
            catch (Exception e)
            { 
                ErrorMessage = "DeleteAssessment: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = assessID });
            }

            // Return to programmes, modules and assessments
            return RedirectToPage("/ListModules");
        }
    }
}