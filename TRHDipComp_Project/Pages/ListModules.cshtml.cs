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
    public class ListModulesModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public IList<Module> ModuleList { get; private set; }

        public IList<ProgrammeModule> ProgrammeModuleList { get; private set; }

        public IList<Programme> ProgrammeList { get; private set; }

        public ListModulesModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get list of Modules, ProgrammeModules and Programmes
            ModuleList = await _db.Modules.AsNoTracking().ToListAsync();
            ProgrammeModuleList = await _db.ProgrammeModules.AsNoTracking().ToListAsync();
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
        }
    }
}