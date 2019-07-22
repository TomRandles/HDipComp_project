using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class ShowAssessmentResultModel : PageModel
    {
        private readonly CollegeDbContext _db;

        [BindProperty]
        public string ProgrammeName { get; private set; } = "";

        [BindProperty]
        public string ModuleName { get; private set; } = "";

        [BindProperty]
        public string AssessmentName { get; private set; } = "";

        [BindProperty]
        public string StudentName { get; private set; } = "";

        private IList<Student> StudentList;

        private IList<Programme> ProgrammeList;

        private IList<Module> ModuleList;

        private IList<Assessment> AssessmentList;

        public ShowAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AssessmentResult AssessmentResult { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            AssessmentResult = await _db.AssessmentResults.FindAsync(id);

            if (AssessmentResult == null)
            {
                return NotFound();
            }

            StudentList = await _db.Students.AsNoTracking().ToListAsync();
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();

            var students = StudentList.Where(s => s.StudentID == AssessmentResult.StudentID);
            StudentName = students.First().FirstName + " " + students.First().SurName;

            AssessmentResult.ProgrammeID = students.First().ProgrammeID;

            ProgrammeName = ProgrammeList.Where(p => p.ProgrammeID == AssessmentResult.ProgrammeID)
                                          .Select(p => p)
                                          .First().ProgrammeName;


            ModuleName = ModuleList.Where(s => s.ModuleID == AssessmentResult.ModuleID)
                                                .First().ModuleName;

            AssessmentName = AssessmentList.Where(s => s.AssessmentID == AssessmentResult.AssessmentID)
                                                        .First().AssessmentName;

            return Page();
        }
    }
}