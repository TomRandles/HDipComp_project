using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.ModulePages.Pages
{
    public class DeleteModuleModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public DeleteModuleModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Module Module { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
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
            try
            {
                var mod = await _db.Modules.FindAsync(Module.ModuleID);

                if (mod != null)
                {
                    _db.Modules.Remove(mod);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "DeleteModule: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteModule: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteModule: invalid operation error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
            }
            catch (Exception e)
            {
                ErrorMessage = "DeleteModule: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Module.ModuleID });
            }
            return RedirectToPage("/ListProgrammeModules", new { area = "ProgrammePages" });
        }
        #endregion
    }
}