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
        public string Message { get; set; } = "";

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
                Message += " ModelState is Valid";

                // Save new Assessment
                _db.Assessments.Add(Assessment);
                await _db.SaveChangesAsync();

                return RedirectToPage("ShowAssessmentDetails", new { id = Assessment.AssessmentID });
            }
            else
            {
                Message += " ModelState is InValid " + ModelState.ToString();
                return Page();
            }
        }
    }
}