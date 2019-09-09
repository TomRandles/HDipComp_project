using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.ModulePages.Pages
{
    public class AddModuleToProgrammeModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }

        public IList<Module> ModuleList { get; private set; }

        [BindProperty]
        public ProgrammeModule ProgrammeModule { get; set; } = new ProgrammeModule();

        [BindProperty]
        public IList<Teacher> Teachers { get; set; }

        public AddModuleToProgrammeModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        public async Task<IActionResult> OnGetAsync()
        {
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            Teachers = await _db.Teachers.AsNoTracking().ToListAsync();

            return Page();

        }


        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid

                try
                {
                    // Save new programme module combo
                    _db.ProgrammeModules.Add(ProgrammeModule);

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "AddModuleToProgramme: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = ProgrammeModule.ModuleID });
 
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "AddModuleToProgramme: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = ProgrammeModule.ModuleID });
                    
                }
                catch (InvalidOperationException e)
                {
                    ErrorMessage = "AddModuleToProgramme: invalid operation error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = ProgrammeModule.ModuleID });
                    
                }
                catch (Exception e)
                {
                    ErrorMessage = "AddModuleToProgramme: General error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = ProgrammeModule.ModuleID });
                }

                return RedirectToPage("/ListProgrammeModules", new { area = "ProgrammePages" });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
        #endregion
    }
}
