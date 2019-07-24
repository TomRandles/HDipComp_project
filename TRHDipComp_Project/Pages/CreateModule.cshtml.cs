using System;
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

        [TempData]
        public string ErrorMessage { get; set; } = "";

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
                // Message += " ModelState is Valid";

                // Save new programmeModule object in DB
                ProgrammeModule.ModuleID = Module.ModuleID;

                try
                {
                    // Save new programme module combo
                    _db.ProgrammeModules.Add(ProgrammeModule);

                    // Save new Module
                    _db.Modules.Add(Module);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "Db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "Db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "General error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
                }

                return RedirectToPage("ShowModuleDetails", new { id = Module.ModuleID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
    }
}