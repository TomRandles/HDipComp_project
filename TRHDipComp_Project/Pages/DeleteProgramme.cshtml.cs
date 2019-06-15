using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class DeleteProgrammeModel : PageModel
    {
        private CollegeDbContext _db;

        public DeleteProgrammeModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Programme Programme { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Programme = await _db.Programmes.FindAsync(id);

            if (Programme == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var prog = await _db.Programmes.FindAsync(Programme.ProgrammeID);

            if (prog != null)
            {
                _db.Programmes.Remove(prog);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("/ListProgrammes");
        }
    }
}