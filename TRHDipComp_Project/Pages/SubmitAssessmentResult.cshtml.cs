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

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        public string ProgrammeName { get; private set; } = "";

        [BindProperty]
        public string StudentName { get; private set; } = "";

        [BindProperty]
        public IList<Module> ModuleList { get; private set; }

        [BindProperty]
        public IList<Module> SelectedModuleList { get; private set; } = new List<Module>();

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

        private IList<Programme> ProgrammeList;

        private IList<Student> StudentList;

        public SubmitAssessmentResultModel(CollegeDbContext db)
        {
            _db = db;

        }

        public async Task<IActionResult> OnGetAsync()
        {
            StudentList = await _db.Students.AsNoTracking().ToListAsync();
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ProgrammeModuleList = await _db.ProgrammeModules.AsNoTracking().ToListAsync();
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();

            // Select programme from student details
            // need to revisit with validation code
            var students = StudentList.Where(s => s.StudentID == AssessmentResult.StudentID);
            AssessmentResult.ProgrammeID = students.FirstOrDefault().ProgrammeID;

            StudentName = students.FirstOrDefault().ToString();

            ProgrammeName = ProgrammeList.Where(p => p.ProgrammeID == AssessmentResult.ProgrammeID)
                                         .Select(p => p)
                                         .FirstOrDefault().ProgrammeName;
            
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
                    }
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is valid
                AssessmentResult.AssessmentResultID = AssessmentResult.StudentID + "-" + 
                                                      AssessmentResult.AssessmentID + "-" +
                                                      AssessmentResult.AssessmentDate.ToString("dd-MM-yyyy");
                try
                {
                    // Save new Assessment result
                    _db.AssessmentResults.Add(AssessmentResult);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "Db update concurrency error: " + e.Message + " " + e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "Db update error: " + e.Message + " " + e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
                }

                return RedirectToPage("ShowAssessmentResult", new { id = AssessmentResult.AssessmentResultID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
    }
}