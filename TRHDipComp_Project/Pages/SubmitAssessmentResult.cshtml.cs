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
    public class SubmitAssessmentResultModel : PageModel
    {

        private readonly CollegeDbContext _db;

        public string Message { get; set; } = "";

        [BindProperty]
        public IList<Student> StudentList { get; private set; }

        [BindProperty]
        public IList<Module> ModuleList { get; private set; }


        [BindProperty]
        public IList<Module> SelectedModuleList { get; private set; } = new List<Module>();

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }

        [BindProperty]
        public IList<ProgrammeModule> ProgrammeModuleList { get; private set; }

        [BindProperty]
        public IList<Assessment> AssessmentList { get; private set; }

        [BindProperty]
        public IList<Assessment> SelectedAssessmentList { get; private set; } = new List<Assessment>();

        [BindProperty]
        public AssessmentResult AssessmentResult { get; set; } = new AssessmentResult();

        [BindProperty]
        public IList<AssessmentResult> ResultList { get; set; }

        public SubmitAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            StudentList = await _db.Students.AsNoTracking().ToListAsync();
            // ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ModuleList = await _db.Modules.ToListAsync();
            ProgrammeModuleList = await _db.ProgrammeModules.AsNoTracking().ToListAsync();
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();

            if (RouteData.Values["id"] != null)
            {
                AssessmentResult.StudentID = RouteData.Values["id"].ToString();
            }

            // Select programme from student details
            // need to revisit with validation code
            var students = StudentList.Where(s => s.StudentID == AssessmentResult.StudentID);
            AssessmentResult.ProgrammeID = students.First().ProgrammeID;

            if (ProgrammeModuleList.Count() != 0)
            {
                var progMods = ProgrammeModuleList.Where(s => s.ProgrammeID == AssessmentResult.ProgrammeID)
                                                               .Select(s => s);

                foreach (var progMod in progMods)
                {
                    var mods = ModuleList.Where(s => s.ModuleID == progMod.ModuleID)
                            .Select(s => s);

                    foreach (var mod in mods)
                    {
                        SelectedModuleList.Add(mod);

                        // @*Get assessments *@
                        if (AssessmentList.Count() != 0)
                        {
                            var assessmentsForThisModule = AssessmentList.Where(
                                                           a => a.ModuleID == @mod.ModuleID)
                                                                 .Select(a => a);

                            foreach (var assess in assessmentsForThisModule)
                            {
                                SelectedAssessmentList.Add(assess);
                            }
                        }
                    }
                }
            }   
                // @*Get assessments *@
                        /*
                        if (Model.AssessmentList.Count() != 0)
                                    {
                                        var assessmentsForThisModule = Model.AssessmentList.Where(
                                                a => a.ModuleID == @mod.ModuleID)
                                                      .Select(a => a);

                                        foreach (var assess in assessmentsForThisModule)
                                        {
                                                < p > @Model.AssessmentResult.StudentID </ p >
                                                < p > @Model.AssessmentResult.ProgrammeID </ p >
                                                < p > @assess.AssessmentName </ p >
                                                < p > @assess.AssessmentTotalMark </ p >
                                            }
                                    }
                                }
                            }
                        }
                        */

             return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Message += " ModelState is Valid";

                // Save new Assessment
                _db.AssessmentResults.Add(AssessmentResult);
                await _db.SaveChangesAsync();

                return RedirectToPage("ShowAssessmentResult", new { id = AssessmentResult.AssessmentResultID });
            }
            else
            {
                Message += " ModelState is InValid " + ModelState.ToString();
                return Page();
            }
        }
    }
}