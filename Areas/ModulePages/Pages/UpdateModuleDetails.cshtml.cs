using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;


namespace TRHDipComp_Project.Areas.ModulePages.Pages
{
    public class UpdateModuleDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public UpdateModuleDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public ProgrammeModule ProgrammeModule { get; set; } = new ProgrammeModule();

        [BindProperty]
        public IList<Programme> ProgrammeListOptions { get; private set; }

        [BindProperty]
        public Module Module { get; set; }
        #endregion

        #region get
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
        #endregion 

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Save modified programmeModule object in DB
                ProgrammeModule.ModuleID = Module.ModuleID;
                _db.Attach(ProgrammeModule).State = EntityState.Modified;

                _db.Attach(Module).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "UpdateModuleDetails: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "UpdateModuleDetails: db Update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "UpdateStudentDetails: invalid operation: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && (e.InnerException.Message != null))
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
            }
            catch (Exception e)
            {
                ErrorMessage = "UpdateModuleDetails: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Module.ModuleID });
            }

            return RedirectToPage("/ShowModuleDetails", new { area = "ModulePages", id = Module.ModuleID });
        }
        #endregion
    }
}