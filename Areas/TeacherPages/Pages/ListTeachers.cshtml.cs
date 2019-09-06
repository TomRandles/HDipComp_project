using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Areas.TeacherPages.Pages
{
    public class ListTeachersModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;


        [BindProperty]
        public IList<Teacher> TeacherList { get; private set; }

        public ListTeachersModel(CollegeDbContext db)
        {
            _db = db;
        }
        #endregion

        #region get
        public async Task OnGetAsync()
        {
            //get list of Teachers
            TeacherList = await _db.Teachers.AsNoTracking().ToListAsync();
        }
        #endregion
    }
}