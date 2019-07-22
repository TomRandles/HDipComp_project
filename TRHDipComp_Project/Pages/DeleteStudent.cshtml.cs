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
    public class DeleteStudentModel : PageModel
    {
        private CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public DeleteStudentModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

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
                ErrorMessage = "Db Update Concurrency error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "Db Update error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }
            catch (Exception e)
            {
                ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }
            return RedirectToPage("/ListStudents");
        }
    }
}