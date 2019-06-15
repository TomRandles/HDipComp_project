using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class CreateModuleModel : PageModel
    {
        private readonly CollegeDbContext _db;
        public string Message { get; set; } = "";

        [BindProperty]
        public IList<Programme> ProgrammeListOptions { get; private set; }

        [BindProperty]
        public Module Module { get; set; } = new Module();

        [BindProperty]
        public ProgrammeModule ProgrammeModule { get; set; } = new ProgrammeModule();

        public CreateModuleModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ProgrammeListOptions = await _db.Programmes.AsNoTracking().ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Message += " ModelState is Valid";

                // Save new programmeModule object in DB
                ProgrammeModule.ModuleID = Module.ModuleID;
                _db.ProgrammeModules.Add(ProgrammeModule);

                // Save new Module
                _db.Modules.Add(Module);
                await _db.SaveChangesAsync();

                return RedirectToPage("ShowModuleDetails", new { id = Module.ModuleID });
            }
            else
            {
                Message += " ModelState is InValid " + ModelState.ToString();
                return Page();
            }
        }
    }
}