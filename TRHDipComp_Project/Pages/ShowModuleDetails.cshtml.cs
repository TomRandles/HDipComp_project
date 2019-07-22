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
    public class ShowModuleDetailsModel : PageModel
    {

        private readonly CollegeDbContext _db;

        public ShowModuleDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Module Module { get; set; }

        public IList<Assessment> AssessmentList { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();

            Module = await _db.Modules.FindAsync(id);

            if (Module == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}