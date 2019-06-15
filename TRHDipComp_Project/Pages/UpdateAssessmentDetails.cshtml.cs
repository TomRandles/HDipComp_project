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
    public class UpdateAssessmentDetailsModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public UpdateAssessmentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IList<Module> ModuleListOptions { get; private set; }

        [BindProperty]
        public Assessment Assessment { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Assessment).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Assessment {Assessment.AssessmentID} not found!");
            }

            return RedirectToPage("/ShowAssessmentDetails");
        }
    }
}