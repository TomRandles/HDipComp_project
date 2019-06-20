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
    public class SearchProgrammeDetailsModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public SearchProgrammeDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        [RegularExpression(@"[\w\.\'\.\s]{1,20}")]
        public string ProgrammeSearchString { get; set; } = "";

        [BindProperty]
        public IList<Programme> ProgrammesFound { get; set; }

        public async Task OnGetAsync()
        {
            if (ModelState.IsValid)
            {

                var Programmes = from s in _db.Programmes
                               select s;

                if (!String.IsNullOrEmpty(ProgrammeSearchString))
                {
                    // Programmes = Programmes.Where(s => s.Title.Contains(ProgrammeSearchString));
                    Programmes = Programmes.Where(s => s.ProgrammeName.Contains(ProgrammeSearchString));
                }

                ProgrammesFound = await Programmes.ToListAsync();

            }
        }
    }
}