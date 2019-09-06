using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.ProgrammePages.Pages
{
    public class CreateProgrammeModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public Programme Programme { get; set; } = new Programme();


        public CreateProgrammeModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid

                try
                {
                    _db.Programmes.Add(Programme);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "CreateProgramme: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message; ;
                    return RedirectToPage("MyErrorMessage", new { id = Programme.ProgrammeID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "CreateProgramme: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorMessage", new { id = Programme.ProgrammeID });
                }
                catch (InvalidOperationException e)
                { 
                    ErrorMessage = "CreateProgramme: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorMessage", new { id = Programme.ProgrammeID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "CreateProgramme: general error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorMessage", new { id = Programme.ProgrammeID });
                }

                return RedirectToPage("/ShowProgrammeDetails", new { area = "ProgrammePages", id = Programme.ProgrammeID });
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