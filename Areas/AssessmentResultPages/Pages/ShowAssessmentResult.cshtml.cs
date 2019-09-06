using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace  TRHDipComp_Project.Areas.AssessmentResultPages.Pages
{
    public class ShowAssessmentResultModel : PageModel
    {
        #region db_properties_ctr
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


        [BindProperty]
        public AssessmentResult AssessmentResult { get; set; }

        public ShowAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;
        }

        #endregion

        #region get
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
            StudentName = students.FirstOrDefault().ToString();

            AssessmentResult.ProgrammeID = students.First().ProgrammeID;

            ProgrammeName = ProgrammeList.Where(p => p.ProgrammeID == AssessmentResult.ProgrammeID)
                                          .Select(p => p)
                                          .FirstOrDefault().ProgrammeName;


            ModuleName = ModuleList.Where(s => s.ModuleID == AssessmentResult.ModuleID)
                                                .FirstOrDefault().ModuleName;

            AssessmentName = AssessmentList.Where(s => s.AssessmentID == AssessmentResult.AssessmentID)
                                                        .FirstOrDefault().AssessmentName;

            return Page();
        }
        #endregion
    }
}