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
    public class CreateAssessmentModel : PageModel
    {

        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public IList<Module> ModuleListOptions { get; private set; }

        [BindProperty]
        public Assessment Assessment { get; set; } = new Assessment();

        public CreateAssessmentModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ModuleListOptions = await _db.Modules.AsNoTracking().ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid
                try
                {
                    // Save new Assessment
                    _db.Assessments.Add(Assessment);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "CreateAssessment: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "CreateAssessment: db update error: ";            
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "CreateAssessment: general error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
                }

                return RedirectToPage("ShowAssessmentDetails", new { id = Assessment.AssessmentID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
    }
}