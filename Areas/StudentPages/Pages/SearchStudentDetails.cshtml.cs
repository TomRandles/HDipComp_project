using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.StudentPages.Pages
{
    public class SearchStudentDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public SearchStudentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.\s\-]{1,20}", ErrorMessage="Alphanumeric characters. Space, hyphens, apostrophes, commas allowed.")]
        public string StudentSearchString { get; set; } = "";

        [BindProperty]
        public IList<Student> StudentsFound { get; set; }
        #endregion

        #region get
        public async Task OnGetAsync()
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(StudentSearchString))
                {
                    var students = await _db.Students.AsNoTracking().ToListAsync();

                    StudentsFound = students.Where(s => s.SurName.Contains(StudentSearchString))
                                            .Select(s => s)
                                            .ToList();
                }
            }
        }
        #endregion
    }
}