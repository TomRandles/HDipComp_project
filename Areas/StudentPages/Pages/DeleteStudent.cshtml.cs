using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.StudentPages.Pages
{
    public class DeleteStudentModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public DeleteStudentModel(CollegeDbContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public Student Student { get; set; }

        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
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
                var stud = await _db.Students.FindAsync(Student.StudentID);

                if (stud != null)
                {
                    _db.Students.Remove(stud);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "DeleteStudent: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteStudent: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteStudent: invalid operation error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
            }

            catch (Exception e)
            {
                ErrorMessage = "DeleteStudent: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
            }

            return RedirectToPage("/ListStudents", new { area = "StudentPages"});
        }
    }
    #endregion
}
