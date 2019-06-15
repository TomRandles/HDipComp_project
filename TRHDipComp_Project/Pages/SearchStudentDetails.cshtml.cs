using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class SearchStudentDetailsModel : PageModel
    {

        private readonly CollegeDbContext _db;

        public SearchStudentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.]{1,20}")]
        public string StudentSearchString { get; set; } = "";

        [BindProperty]
        public IList<Student> StudentsFound { get; set; }

        public async Task OnGetAsync()
        {
            if (ModelState.IsValid)
            {

                var students = from s in _db.Students
                               select s;

                if (!String.IsNullOrEmpty(StudentSearchString))
                {
                    // students = students.Where(s => s.Title.Contains(StudentSearchString));
                    students = students.Where(s => s.SurName.Contains(StudentSearchString));
                }

                StudentsFound = await students.ToListAsync();

            }
        }
    }
}