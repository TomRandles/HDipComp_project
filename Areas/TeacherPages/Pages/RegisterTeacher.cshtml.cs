using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.TeacherPages.Pages
{
    public class RegisterTeacherModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        [Display(Name = "Upload a Teacher picture (optional)")]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Teacher Teacher { get; set; } = new Teacher();

        public RegisterTeacherModel(CollegeDbContext db)
        {
            _db = db;

            // GetRandomID can only be called in the Registration process; 
            // did not belong in the Teacher constructor
            Teacher.TeacherID = Teacher.GetRandomID();
        }
        #endregion

        #region get
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid

                // Picture upload is optional; check if the IForm variable is set
                if (Upload != null)
                {
                    // Get the length of the binary stream
                    long numBytesRead = Upload.Length;

                    // create new byte array
                    Teacher.TeacherImage = new byte[numBytesRead];

                    // Update with binary data
                    using (var memoryStream = new MemoryStream())
                    {
                        await Upload.CopyToAsync(memoryStream);
                        Teacher.TeacherImage = memoryStream.ToArray();
                    }
                }

                // Save new Teacher entity
                try
                {
                    _db.Teachers.Add(Teacher);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "Register Teacher: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("Error", new { id = Teacher.TeacherID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "Register Teacher: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("Error", new { id = Teacher.TeacherID });
                }
                catch (InvalidOperationException e)
                {
                    ErrorMessage = "RegisterTeacher: invalid operation: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("Error", new { id = Teacher.TeacherID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "Register Teacher: general error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("Error", new { id = Teacher.TeacherID });
                }

          
                return RedirectToPage("/ShowTeacherDetails", new { area = "TeacherPages", id = Teacher.TeacherID });
                    
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