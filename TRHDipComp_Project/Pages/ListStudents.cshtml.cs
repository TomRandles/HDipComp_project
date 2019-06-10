using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;


namespace TRHDipComp_Project.Pages
{
    public class ListStudentsModel : PageModel
    {
        private readonly CollegeDbContext _db;

        public IList<Student> StudentList { get; private set; }

        public ListStudentsModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            //get list of Students
            StudentList = await _db.Students.AsNoTracking().ToListAsync();

        }
    }
}