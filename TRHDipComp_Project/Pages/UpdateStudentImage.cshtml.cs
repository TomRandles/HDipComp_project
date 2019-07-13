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
    public class UpdateStudentImageModel : PageModel
    {
        private readonly CollegeDbContext _db;

        private IHostingEnvironment _environment;

        public UpdateStudentImageModel(IHostingEnvironment environment, CollegeDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task OnPostAsync()
        {
            int numBytesToRead = 0;

            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            // var filePath = Path.GetTempFileName();

            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
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

                // Save modified Student object in DB
                _db.Attach(Student).State = EntityState.Modified; ;

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new Exception($"Student {Student.StudentID} not found!");
                }
            }
        }
    }
}