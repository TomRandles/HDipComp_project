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
    public class DeleteProgrammeModel : PageModel
    {
        private CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

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
            try
            {
                var prog = await _db.Programmes.FindAsync(Programme.ProgrammeID);

                if (prog != null)
                {
                    _db.Programmes.Remove(prog);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "Db Update Concurrency error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "Db Update error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (Exception e)
            {
                ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }

            return RedirectToPage("/ListProgrammes");
        }
    }
}