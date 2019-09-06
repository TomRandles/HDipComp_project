using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;


namespace TRHDipComp_Project.Areas.TeacherPages.Pages
{
    public class ShowTeacherDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public ShowTeacherDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Teacher Teacher { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Teacher = await _db.Teachers.FindAsync(id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}