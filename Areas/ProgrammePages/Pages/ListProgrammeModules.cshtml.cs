using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;


namespace TRHDipComp_Project.Areas.ProgrammePages.Pages
{
    public class ListProgrammeModulesModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.\s\,]{1,30}", ErrorMessage ="Alphanumeric characters. Space, hyphens, periods, commas, apostrophes accepted.")]
        [StringLength(30)]
        public string ProgrammeSearchString { get; set; } = "";

        [BindProperty]
        public IList<Programme> ProgrammesFound { get; set; }

        [BindProperty]
        public IList<Module> ModuleList { get; private set; }

        [BindProperty]
        public IList<ProgrammeModule> ProgrammeModuleList { get; private set; }

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }

        [BindProperty]
        public IList<Assessment> AssessmentList { get; private set; }

        [BindProperty]
        public IList<Assessment> AssessmentsPerModule { get; set; }

        [BindProperty]
        public Dictionary<string, string> ModulesInProgramme { get; private set; } = new Dictionary<string, string>();
      
        public ListProgrammeModulesModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        #region get
        public async Task OnGetAsync()
        {

            // Not lists are populated without a search string
            if (!String.IsNullOrEmpty(ProgrammeSearchString))
            {
                ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();

                ProgrammesFound = ProgrammeList.Where(s => s.ProgrammeName.Contains(ProgrammeSearchString))
                               .Select(s => s)
                               .ToList();

                if (ProgrammesFound.Count() != 0 )
                {
                    ProgrammeModuleList = await _db.ProgrammeModules.AsNoTracking().ToListAsync();

                    //get list of Modules, ProgrammeModules and Programmes, Assessments
                    ModuleList = await _db.Modules.AsNoTracking().ToListAsync();


                    // Populate ModulesInProgramme
                    foreach (var progMod in ProgrammeModuleList)
                    {
                        ModulesInProgramme.Add(progMod.ProgrammeID + progMod.ModuleID, progMod.ProgrammeID);
                    }

                    AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();
                }
            }
        }
        #endregion
    }
}