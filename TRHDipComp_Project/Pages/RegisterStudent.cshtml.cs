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
    public class RegisterStudentModel : PageModel
    {
        private readonly CollegeDbContext _db;
        public string Message { get; set; } = "";

        [BindProperty]
        public Student Student { get; set; } = new Student();

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }

        public RegisterStudentModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Message += " ModelState is Valid: " + Student.ProgrammeID;

                _db.Students.Add(Student);
                await _db.SaveChangesAsync();

                return RedirectToPage("ShowStudentDetails", new { id = Student.StudentID });
            }
            else
            {
                Message += " ModelState is InValid";
                return Page();
            }
        }
    }
}