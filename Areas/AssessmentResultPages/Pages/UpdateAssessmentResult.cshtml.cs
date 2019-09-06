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
    public class UpdateAssessmentResultModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public UpdateAssessmentResultModel (CollegeDbContext db)
        {
            _db = db;
        }

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

        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public AssessmentResult AssessmentResult { get; set; }
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
                                                .First().ModuleName;

            AssessmentName = AssessmentList.Where(s => s.AssessmentID == AssessmentResult.AssessmentID)
                                                        .First().AssessmentName;

            return Page();
        }
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Save modified UpdateAssessmentResult object in DB
                _db.Attach(AssessmentResult).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "UpdateAssessmentResult: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "UpdateAssessmentResult: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "UpdateStudentDetails: invalid operation: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
            }
            catch (Exception e)
            {
                ErrorMessage = "UpdateAssessmentResult: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = AssessmentResult.AssessmentResultID });
            }

            return RedirectToPage("/ShowAssessmentResult", new { area = "AssessmentResultPages", id = AssessmentResult.AssessmentResultID });
        }
    }
    #endregion
}
