using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.ModulePages.Pages
{
    public class CreateModuleModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public IList<Programme> ProgrammeListOptions { get; private set; }

        [BindProperty]
        public Module Module { get; set; } = new Module();

        [BindProperty]
        public ProgrammeModule ProgrammeModule { get; set; } = new ProgrammeModule();


        [BindProperty]
        public IList<Teacher> Teachers { get;  set; }

        public CreateModuleModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync()
        {
            // Get list of programmes available
            ProgrammeListOptions = await _db.Programmes.AsNoTracking().ToListAsync();

            // Get list of teachers - one of whom will be assigned to teach this module
            Teachers = await _db.Teachers.AsNoTracking().ToListAsync();

            return Page();
        }
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid

                // Save new programmeModule object in DB
                ProgrammeModule.ModuleID = Module.ModuleID;

                try
                {
                    // Save new programme-module combo
                    _db.ProgrammeModules.Add(ProgrammeModule);

                    // Save new Module
                    _db.Modules.Add(Module);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "CreateModule: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });

                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "CreateModule: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
                }
                catch (InvalidOperationException e)
                {
                    ErrorMessage = "CreateModule: invalid operation error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "CreateModule: General error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
                }

                return RedirectToPage("/ShowModuleDetails", new { area = "ModulePages", id = Module.ModuleID });
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