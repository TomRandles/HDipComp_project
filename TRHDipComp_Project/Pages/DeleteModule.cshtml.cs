using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class DeleteModuleModel : PageModel
    {
        private CollegeDbContext _db;

        public DeleteModuleModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Module Module { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Module = await _db.Modules.FindAsync(id);

            if (Module == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var mod = await _db.Modules.FindAsync(Module.ModuleID);

            if (mod != null)
            {
                _db.Modules.Remove(mod);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("/ListModules");
        }
    }
}