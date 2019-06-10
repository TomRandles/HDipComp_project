using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace TRHDipComp_Project.Pages
{
    public class ListProgrammesModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public IList<Programme> ProgrammeList { get; private set; }

        public ListProgrammesModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get list of Programmes
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
           
        }
    }
}