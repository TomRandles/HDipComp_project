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
                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "CreateProgramme: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }
                catch (InvalidOperationException e)
                { 
                    ErrorMessage = "CreateProgramme: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "CreateProgramme: general error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
                }

                return RedirectToPage("ShowProgrammeDetails", new { id = Programme.ProgrammeID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
    }
}