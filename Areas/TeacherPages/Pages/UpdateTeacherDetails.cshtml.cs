using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;


namespace TRHDipComp_Project.Areas.TeacherPages.Pages
{
    public class UpdateTeacherDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public UpdateTeacherDetailsModel(CollegeDbContext db)
        {
            _db = db;
            GetProgrammeList();
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        [Display(Name = "Upload a Teacher picture (optional)")]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Teacher Teacher { get; set; }

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Teacher = await _db.Teachers.FindAsync(id);

            if (Teacher == null)
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

            // Save updated entity 
            try
            {
                _db.Attach(Teacher).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "UpdateTeacherDetails: Db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "UpdateTeacherDetails: DB update exception: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "UpdateTeacherDetails: invalid operation: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }
            catch (Exception e)
            {
                ErrorMessage = "UpdateTeacherDetails: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }

            return RedirectToPage("/ShowTeacherDetails", new { area = "TeacherPages", id = Teacher.TeacherID });
        }
        #endregion

        private void GetProgrammeList()
        {
            ProgrammeList = _db.Programmes.AsNoTracking().ToList();
        }
    }
}