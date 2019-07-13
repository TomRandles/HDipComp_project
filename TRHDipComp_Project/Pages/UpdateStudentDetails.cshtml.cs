using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class UpdateStudentDetailsModel : PageModel
    {
        private IHostingEnvironment _environment;

        private readonly CollegeDbContext _db;

        public UpdateStudentDetailsModel(IHostingEnvironment environment, CollegeDbContext db)
        {
            _db = db;
            _environment = environment;
            GetProgrammeList();
        }

        [BindProperty]
        public IFormFile Upload { get; set; }

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

            int numBytesToRead = 0;

            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            try
            {
                using (var fileStream = new MyFileStream(file, FileMode.Open))
                {
                    await Upload.opyToAsCync(fileStream);
                    int numBytesRead = 0;
                    numBytesToRead = (int)Upload.Length;
                    Student.StudentImage = new byte[numBytesToRead];

                    // Copy bytestream to byte array propery in Student class
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fileStream.Read(Student.StudentImage, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                }
            }
            catch (Exception e)
            {

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