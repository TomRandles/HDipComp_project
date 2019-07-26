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
    public class DeleteAssessmentResultModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public DeleteAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string ErrorMessage { get; set; }

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
            // Local copy of ID to use in exception management.
            string assessResultID = AssessmentResult.AssessmentResultID;

            try
            {
                var assessResult = await _db.AssessmentResults.FindAsync(AssessmentResult.AssessmentResultID);

                if (assessResult != null)
                {
                    _db.AssessmentResults.Remove(assessResult);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "DeleteAssessmentResult: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteAssessmentResult: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteAssessmentResult: invalid operation error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }
            catch (Exception e)
            {
                ErrorMessage = "DeleteAssessmentResult: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }

            return RedirectToPage("/ListAssessmentResults");
        }
    }
}