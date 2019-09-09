using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.TeacherPages.Pages
{
    public class DeleteTeacherModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public DeleteTeacherModel(CollegeDbContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public Teacher Teacher { get; set; }

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
            try
            {
                var stud = await _db.Teachers.FindAsync(Teacher.TeacherID);

                if (stud != null)
                {
                    _db.Teachers.Remove(stud);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "DeleteTeacher: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });

            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteTeacher: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteTeacher: invalid operation error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }

            catch (Exception e)
            {
                ErrorMessage = "DeleteTeacher: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Teacher.TeacherID });
            }

            return RedirectToPage("/ListTeachers", new { area = "TeacherPages" });
        }
        #endregion
    }
}