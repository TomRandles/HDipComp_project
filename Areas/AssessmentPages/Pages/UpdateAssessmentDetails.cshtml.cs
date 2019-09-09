using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.AssessmentPages.Pages
{
    public class UpdateAssessmentDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public UpdateAssessmentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IList<Module> ModuleListOptions { get; private set; }

        [BindProperty]
        public Assessment Assessment { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            ModuleListOptions = await _db.Modules.AsNoTracking().ToListAsync();

            Assessment = await _db.Assessments.FindAsync(id);

            if (Assessment == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _db.Attach(Assessment).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "UpdateAssessmentDetails: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Assessment.AssessmentID });

            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "UpdateAssessmentDetails: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Assessment.AssessmentID });
            }
            catch (Exception e )
            {
                ErrorMessage = "UpdateAssessmentDetails: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Assessment.AssessmentID });
            }

            return RedirectToPage("/ShowAssessmentDetails", new { area = "AssessmentPages", id = Assessment.AssessmentID });

        }
        #endregion
    }
}