using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TRHDipComp_Project.Models.Database;


namespace TRHDipComp_Project.Areas.ProgrammePages.Pages
{
    public class ListProgrammesModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        [BindProperty]
        public IList<Programme> ProgrammeList { get; set; }

        public ListProgrammesModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        #region get
        public async Task OnGetAsync()
        {
            //get list of Programmes
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
        }
        #endregion
    }
}