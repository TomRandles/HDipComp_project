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
    public class CreateProgrammeModel : PageModel
    {
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public Programme Programme { get; set; } = new Programme();


        public CreateProgrammeModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // message += " ModelState is Valid";

                try
                {
                    _db.Programmes.Add(Programme);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "Db update Concurrency error: " + e.Message + " " + e.InnerException.Message; ;
                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "Db update error: " + e.Message + " " + e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }

                return RedirectToPage("ShowProgrammeDetails", new { id = Programme.ProgrammeID });
            }
            else
            {
                // message += " ModelState is InValid";
                return Page();
            }
        }
    }
}