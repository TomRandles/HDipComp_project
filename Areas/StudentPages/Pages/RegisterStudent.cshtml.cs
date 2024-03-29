﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;
using TRHDipComp_Project.Models.Database;
using Microsoft.AspNetCore.Identity;

namespace TRHDipComp_Project.Areas.StudentPages.Pages
{
    public class RegisterStudentModel : PageModel
    {
        #region db_properties_ctr
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


        public RegisterStudentModel(CollegeDbContext db)
        {
            _db = db;
 
            // GetRandomID can only be called in the Registration process; 
            // did not belong in the Student constructor
            Student.StudentID = Student.GetRandomID();
        }
        #endregion

        #region get
        public async Task<IActionResult> OnGetAsync()
        {
            ProgrammeList = await _db.Programmes.AsNoTracking().ToListAsync();
            return Page();
        }
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // ModelState is Valid

                // Picture upload is optional; check if the IForm variable is set
                if (Upload != null)
                {
                    // Get the length of the binary stream
                    long numBytesRead = Upload.Length;

                    // create new byte array
                    Student.StudentImage = new byte[numBytesRead];

                    // Update with binary data
                    using (var memoryStream = new MemoryStream())
                    {
                        await Upload.CopyToAsync(memoryStream);
                        Student.StudentImage = memoryStream.ToArray();
                    }
                }

                // Save new student entity
                try
                {
                    _db.Students.Add(Student);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    ErrorMessage = "Register student: db update concurrency error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
                }
                catch (DbUpdateException e)
                {
                    ErrorMessage = "Register student: db update error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
                }
                catch (InvalidOperationException e)
                {
                    ErrorMessage = "RegisterStudent: invalid operation: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if ((e.InnerException != null) && ((e.InnerException.Message != null)))
                        ErrorMessage += e.InnerException.Message;
                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
                }
                catch (Exception e)
                {
                    ErrorMessage = "Register student: general error: ";
                    if (e.Message != null)
                        ErrorMessage += e.Message;
                    if (e.InnerException.Message != null)
                        ErrorMessage += e.InnerException.Message;

                    return RedirectToPage("/MyErrorPage", new { area = "ErrorPages", id = Student.StudentID });
                }

                return RedirectToPage("/ShowStudentDetails", new { area = "StudentPages", id = Student.StudentID });
            }
            else
            {
                // ModelState is InValid
                return Page();
            }
        }
        #endregion
    }
}
