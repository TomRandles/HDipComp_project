using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace TRHDipComp_Project.Pages
{
    public class ListStudentsModel : PageModel
    {
        private readonly CollegeDbContext _db;

        // SupportsGet = true. Necessary to pass a value to the server via OnGet. Is a security 
        // compromise
        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.\s]{1,20}")]
        public string ProgrammeSearchString { get; set; } = "";

        [BindProperty]
        public IList<Programme> ProgrammesFound { get; set; }

        [BindProperty]
        public IList<Programme> ProgrammesList { get; set; }

        [BindProperty]
        public IList<Student> StudentList { get; private set; }

        [BindProperty]
        public IList<Student> SelectedStudentList { get; set; } = new List<Student>();

        public ListStudentsModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get list of Students
            StudentList = await _db.Students.AsNoTracking().ToListAsync();
            ProgrammesList = await _db.Programmes.AsNoTracking().ToListAsync();

            if (!String.IsNullOrEmpty(ProgrammeSearchString))
            {
                ProgrammesFound = ProgrammesList.Where(s => s.ProgrammeName.Contains(ProgrammeSearchString))
                                                .Select(s => s)
                                                .ToList();
            }
            else
            {
                ProgrammesFound = await _db.Programmes.AsNoTracking().ToListAsync();
            }

            if (ProgrammesFound.Count() != 0)
            {
                foreach (var programme in ProgrammesFound)
                {

                    var students = StudentList.Where(s => s.ProgrammeID == programme.ProgrammeID)
                                              .Select(s => s);

                    foreach (var student in students)
                    {
                        SelectedStudentList.Add(student);
                    }
                }
            }
            else
            {
                SelectedStudentList = StudentList.ToList();
            }
        }
    }
}