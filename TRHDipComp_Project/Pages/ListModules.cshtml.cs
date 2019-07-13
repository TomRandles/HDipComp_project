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
    public class ListModulesModel : PageModel
    {
        private readonly CollegeDbContext _db;

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.\s]{1,20}")]
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
        public Dictionary<string, string> ModulesInProgramme { get; private set; } = new Dictionary<string, string>();
      
        public ListModulesModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            // var Programmes = from s in _db.Programmes
            //                 select s;

            //get list of Modules, ProgrammeModules and Programmes, Assessments
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ProgrammeModuleList = await _db.ProgrammeModules.AsNoTracking().ToListAsync();

            // Populate ModulesInProgramme
            foreach (var progMod in ProgrammeModuleList)
            {
                ModulesInProgramme.Add(progMod.ProgrammeID + progMod.ModuleID, progMod.ProgrammeID);
            }
           
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            AssessmentList = await _db.Assessments.AsNoTracking().ToListAsync();


            var programmes = from s in _db.Programmes
                             select s;

            if (!String.IsNullOrEmpty(ProgrammeSearchString))
            {
                programmes = programmes.Where(s => s.ProgrammeName.Contains(ProgrammeSearchString));
            }
            ProgrammesFound = await programmes.ToListAsync();
        }
    }
}