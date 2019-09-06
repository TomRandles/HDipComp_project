using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.AssessmentPages.Pages
{
    public class ShowAssessmentDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public ShowAssessmentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Assessment Assessment { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Assessment = await _db.Assessments.FindAsync(id);

            if (Assessment == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}