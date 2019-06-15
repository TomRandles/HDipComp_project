using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class UpdateStudentDetailsModel : PageModel
    {

        private readonly CollegeDbContext _db;

        public UpdateStudentDetailsModel(CollegeDbContext db)
        {
            _db = db;
            GetProgrammeList();
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Student).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Student {Student.StudentID} not found!");
            }

            return RedirectToPage("/ShowStudentDetails");
        }
        private async void GetProgrammeList()
        {
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
        }
    }
}