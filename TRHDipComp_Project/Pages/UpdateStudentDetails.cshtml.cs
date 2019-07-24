using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class UpdateStudentDetailsModel : PageModel
    {
        private IHostingEnvironment _environment;

        private readonly CollegeDbContext _db;

        public UpdateStudentDetailsModel(IHostingEnvironment environment, CollegeDbContext db)
        {
            _db = db;
            _environment = environment;
            GetProgrammeList();
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        [Display(Name = "Upload a student picture (optional)")]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }

        public async  Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async  Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Picture upload is optional; check if the IForm variable is set
            if (Upload != null)
            {
                string file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
                Student.ReadStudentImage(file);
            }

            _db.Attach(Student).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "Db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DB update exception: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "Invalid operation: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }
                       
            catch (Exception e)
            {
                ErrorMessage = "General error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
            }

            return RedirectToPage("/ShowStudentDetails");
        }
        private void GetProgrammeList()
        {
            ProgrammeList = _db.Programmes.AsNoTracking().ToList();
        }
    }
}