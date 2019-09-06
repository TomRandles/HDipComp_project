using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database; 


namespace TRHDipComp_Project.Areas.StudentPages.Pages
{
    public class ShowStudentResultsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [BindProperty]
        public string StudentName { get; private set; } = "";

        [BindProperty]
        public string ProgrammeName { get; private set; } = "";

        [BindProperty]
        public string ModuleName { get; private set; } = "";

        [BindProperty]
        public string AssessmentName { get; private set; } = "";

        private IList<Programme> ProgrammeList;

        [BindProperty]
        public IList<Module> ModuleList { get; set; }

        [BindProperty]
        public IList<AssessmentResult> AssessmentResultsList { get; set; }

        [BindProperty]
        public IList<Assessment> AssessmentsList { get; set; }

        [BindProperty]
        public IList<AssessmentResult> StudentAssessmentResultsList { get; set; } = new List<AssessmentResult>();

        public ShowStudentResultsModel(CollegeDbContext db)
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

            StudentName = Student.ToString();

            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            AssessmentResultsList = await _db.AssessmentResults.AsNoTracking().ToListAsync();
            AssessmentsList = await _db.Assessments.AsNoTracking().ToListAsync();

            var programmes = ProgrammeList.Where(p => p.ProgrammeID == Student.ProgrammeID);
            
            ProgrammeName = programmes.First().ProgrammeName;

            StudentAssessmentResultsList = AssessmentResultsList.Where(a => a.StudentID == Student.StudentID)
                                                                      .Select(a => a)
                                                                      .ToList();    
            return Page();
        }
        #endregion
    }
}