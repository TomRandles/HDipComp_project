﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.AssessmentResultPages.Pages
{
    public class DeleteAssessmentResultModel : PageModel
    {
        #region db_ctr_properties
        private readonly CollegeDbContext _db;

        public DeleteAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public AssessmentResult AssessmentResult { get; set; }

        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            AssessmentResult = await _db.AssessmentResults.FindAsync(id);

            if (AssessmentResult == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion

        #region post
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
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = assessResultID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteAssessmentResult: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = assessResultID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteAssessmentResult: invalid operation error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = assessResultID });
            }
            catch (Exception e)
            {
                ErrorMessage = "DeleteAssessmentResult: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = assessResultID });        
            }
            return RedirectToPage("/ListAssessmentResults", new { area = "AssessmentResultPages" });
        }
    }
    #endregion
}