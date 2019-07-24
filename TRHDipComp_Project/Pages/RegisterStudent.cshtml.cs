﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class RegisterStudentModel : PageModel
    {
        private IHostingEnvironment _environment;

        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; } = "";

        [BindProperty]
        [Display(Name = "Upload a student picture (optional)")]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        [BindProperty]
        public IList<Programme> ProgrammeList { get; private set; }

        public RegisterStudentModel(IHostingEnvironment environment, CollegeDbContext db)
        {
            _db = db;
            _environment = environment;

            // GetRandomID can only be called in the Registration process; 
            // did not belong in the Student constructor
            Student.StudentID = Student.GetRandomID();
        }      

        public async Task<IActionResult> OnGetAsync()
        {
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid

                // Picture upload is optional; check if the IForm variable is set
                if (Upload != null)
                {
                    string file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
                    Student.ReadStudentImage(file);
                }

                try
                {
                    _db.Students.Add(Student);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "Db Update Concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "Db Update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "General error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("MyErrorPage", new { id = Student.StudentID });
                }

                return RedirectToPage("ShowStudentDetails", new { id = Student.StudentID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
    }
}