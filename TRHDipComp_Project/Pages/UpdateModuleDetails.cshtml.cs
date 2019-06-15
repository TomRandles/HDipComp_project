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
    public class UpdateModuleDetailsModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public UpdateModuleDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ProgrammeModule ProgrammeModule { get; set; } = new ProgrammeModule();

        [BindProperty]
        public IList<Programme> ProgrammeListOptions { get; private set; }

        [BindProperty]
        public Module Module { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            ProgrammeListOptions = await _db.Programmes.AsNoTracking().ToListAsync();

            Module = await _db.Modules.FindAsync(id);

            if (Module == null)
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

            // Save modified programmeModule object in DB
            ProgrammeModule.ModuleID = Module.ModuleID;
            _db.Attach(ProgrammeModule).State = EntityState.Modified; ;

            _db.Attach(Module).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Module {Module.ModuleID} not found!");
            }

            return RedirectToPage("/ShowModuleDetails");
        }
    }
}