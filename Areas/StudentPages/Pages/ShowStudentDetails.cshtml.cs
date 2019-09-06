using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.StudentPages.Pages
{
    public class ShowStudentDetailsModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        public ShowStudentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IList<Programme> ProgrammesList { get; set; }

        [BindProperty]
        public Student Student { get; set; }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync(string id)
        {
            ProgrammesList = await _db.Programmes.AsNoTracking().ToListAsync();

            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}