using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.AssessmentResultPages.Pages
{
    public class SubmitAssessmentResultModel : PageModel
    {
        #region db_properties_ctr
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
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentList = await _db.Students.AsNoTracking().ToListAsync();
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ProgrammeModuleList = await _db.ProgrammeModules.AsNoTracking().ToListAsync();
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();


            // Should only be one student returned here
            var students = StudentList.Where(s => s.StudentID == id)
                                      .Select(s => s);

            if ((students != null) && (students.Count() == 1))
            {
                // Extract relevant details from the student object
                AssessmentResult.ProgrammeID = students.FirstOrDefault().ProgrammeID;
                AssessmentResult.StudentID = students.FirstOrDefault().StudentID;
                StudentName = students.FirstOrDefault().ToString();

                // Get the relevant programme name
                ProgrammeName = ProgrammeList.Where(p => p.ProgrammeID == AssessmentResult.ProgrammeID)
                                             .Select(p => p)
                                             .FirstOrDefault().ProgrammeName;

                // Populate select module list for this programme
                if (ProgrammeModuleList.Count() != 0)
                {
                    var progMods = ProgrammeModuleList.Where(s => s.ProgrammeID == AssessmentResult.ProgrammeID)
                                                                   .Select(s => s);

                    if (progMods != null)
                    {
                        foreach (var progMod in progMods)
                        {
                            var mods = ModuleList.Where(s => s.ModuleID == progMod.ModuleID)
                                    .Select(s => s);

                            foreach (var mod in mods)
                            {
                                SelectedModuleList.Add(mod);
                            }
                        }
                        return Page();
                    }
                    else
                    {
                        //Error - no programme assigned to this student
                        ErrorMessage = $"Error: there is no programme assigned to this student: {AssessmentResult.StudentID}";
                        return RedirectToPage("Error", new { id = AssessmentResult.AssessmentResultID });
                    }
                }
                else
                {
                    //Error - Prog Mods is null
                    ErrorMessage = "Error: the Programme - Modules table is empty; cannot process assessment submission";
                    return RedirectToPage("Error", new { id = AssessmentResult.AssessmentResultID });
                }
            }
            else
            {
                // Student not found
                return NotFound();
            }
        }
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is valid
                // Populate assessment result ID from 3 components
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
                    ErrorMessage = "SubmitAssessmentResult: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorMessage", new { id = AssessmentResult.AssessmentResultID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "SubmitAssessmentResult: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorMessage", new { id = AssessmentResult.AssessmentResultID });
                }
                catch (InvalidOperationException e)
                {
                    ErrorMessage = "SubmitAssessmentResult: invalid operation: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorMessage", new { id = AssessmentResult.AssessmentResultID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "SubmitAssessmentResult: general error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorMessage", new { id = AssessmentResult.AssessmentResultID });
                }

                return RedirectToPage("/ShowAssessmentResult", new { area = "AssessmentResultPages", id = AssessmentResult.AssessmentResultID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
        #endregion
    }
}