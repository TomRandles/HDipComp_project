using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;


namespace TRHDipComp_Project.Areas.ModulePages.Pages
{
    public class ShowModuleDetailsModel : PageModel
    {
        #region db_properties_ctr

        private readonly CollegeDbContext _db;

        public ShowModuleDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string SelectedTeacherName { get; set; }

        [BindProperty]
        public Module Module { get; set; }

        public IList<Module> ModuleList { get; set; }

        public IList<Programme> ProgrammeList { get; set; }

        public IList<Assessment> AssessmentList { get; set; }

        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Module = await _db.Modules.FindAsync(id);

            if (Module == null)
            {
                return NotFound();
            }
 
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();

            // Get the assigned teacher for this module - optional
            string teacherID = _db.ProgrammeModules.Where(m => m.ModuleID == Module.ModuleID)
                                                   .Select(m => m.TeacherID)
                                                   .FirstOrDefault();

            if (!string.IsNullOrEmpty(teacherID))
            {
                Teacher teacher = await _db.Teachers.FindAsync(teacherID);
                if (teacher != null)
                {
                    SelectedTeacherName = teacher.ToString();
                }
            }

            return Page();
        }
        #endregion
    }
}