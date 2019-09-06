using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.ProgrammePages.Pages
{
    public class UpdateProgrammeDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public UpdateProgrammeDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public Programme Programme { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Programme = await _db.Programmes.FindAsync(id);

            if (Programme == null)
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
                _db.Attach(Programme).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "UpdateProgrammeDetails: db update concurrency error: ";          
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "UpdateProgrammeDetails: db Update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "UpdateStudentDetails: invalid operation: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (Exception e)
            {
                ErrorMessage = "UpdateProgrammeDetails: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }

            return RedirectToPage("/ShowProgrammeDetails", new { area = "ProgrammePages", id = Programme.ProgrammeID });
        }
        #endregion
    }
}