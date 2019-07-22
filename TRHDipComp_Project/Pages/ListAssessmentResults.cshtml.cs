using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class ListAssessmentResultsModel : PageModel
    {

        // SupportsGet = true. Necessary to pass a value to the server via OnGet. Is a security 
        // compromise
        [BindProperty(SupportsGet = true)]
        public string ProgrammeID { get; set; } = "";

        private readonly CollegeDbContext _db;

        [BindProperty]
        public IList<Programme> ProgrammesList { get; set; }

        [BindProperty]
        public IList<Programme>  ProgrammesFound { get; set; }

        [BindProperty]
        public IList<Student> StudentsList { get; private set; }

        [BindProperty]
        public IList<Module> ModulesList { get; private set; }

        [BindProperty]
        public IList<Assessment> AssessmentsList { get; private set; }

        [BindProperty]
        public IList<AssessmentResult> AssessmentResultsFound { get; set; } = new List<AssessmentResult>();

        [BindProperty]
        public IList<AssessmentResult> AssessmentResultsList { get; private set; }

        public ListAssessmentResultsModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            // Populate lists required for List of Assessments results
            AssessmentResultsList = await _db.AssessmentResults.AsNoTracking().ToListAsync();
            ModulesList = await _db.Modules.AsNoTracking().ToListAsync();
            AssessmentsList = await _db.Assessments.AsNoTracking().ToListAsync();
            StudentsList = await _db.Students.AsNoTracking().ToListAsync();
            ProgrammesList = await _db.Programmes.AsNoTracking().ToListAsync();

            if ((ProgrammeID.Length == 0) || (ProgrammeID == "All"))
            {
                ProgrammesFound = ProgrammesList.Select(p => p).ToList();
            }
            else
            {
                ProgrammesFound = ProgrammesList.Where(p => p.ProgrammeID == ProgrammeID)
                                                .Select(p => p)
                                                .ToList();
            }

            if (ProgrammesFound.Count() != 0)
            {
                foreach (var programme in ProgrammesFound)
                {
                    var assessmentResults = AssessmentResultsList.Where(a => a.ProgrammeID == programme.ProgrammeID)
                                                                 .Select(a => a);

                    foreach (var assessResult in assessmentResults)
                    {
                        AssessmentResultsFound.Add(assessResult);
                    }
                }
            }
            else
            {
                foreach (var assessResult in AssessmentResultsList)
                {
                    AssessmentResultsFound.Add(assessResult);
                }
            }
        }
    }
}