using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.ProgrammePages.Pages
{
    public class ShowProgrammeDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public ShowProgrammeDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Programme Programme { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Programme = await _db.Programmes.FindAsync(id);

            if (Programme == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}