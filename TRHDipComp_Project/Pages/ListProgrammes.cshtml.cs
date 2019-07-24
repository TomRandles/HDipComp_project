using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;

namespace TRHDipComp_Project.Pages
{
    public class ListProgrammesModel : PageModel
    {
        private readonly CollegeDbContext _db;

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.\s\-]{1,20}")]
        public string ProgrammeSearchString { get; set; } = "";

        private IList<Programme> ProgrammeList { get; set; }

        [BindProperty]
        public IList<Programme> ProgrammesFound { get; set; }

        public ListProgrammesModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get list of Programmes
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();

            if (!String.IsNullOrEmpty(ProgrammeSearchString))
            {
                ProgrammesFound = ProgrammeList.Where(s => s.ProgrammeName.Contains(ProgrammeSearchString))
                                               .Select(s => s)
                                               .ToList();
            }
            else
            {
                ProgrammesFound = ProgrammeList.ToList();
            }
        }
    }
}