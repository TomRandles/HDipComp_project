﻿using System;
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
        private CollegeDbContext _db;

        public DeleteAssessmentResultModel ( CollegeDbContext db)
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

                if ( assessResult != null)
                { 
                    _db.AssessmentResults.Remove(assessResult);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "Db Update Concurrency error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "Db Update error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }
            catch (Exception e)
            {
                ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = assessResultID });
            }

            return RedirectToPage("/ListAssessmentResults");
        }
    }
}