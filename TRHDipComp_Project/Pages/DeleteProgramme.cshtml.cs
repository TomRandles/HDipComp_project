﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TRHDipComp_Project.Models;

namespace TRHDipComp_Project.Pages
{
    public class DeleteProgrammeModel : PageModel
    {
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public DeleteProgrammeModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Programme Programme { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Programme = await _db.Programmes.FindAsync(id);

            if (Programme == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var prog = await _db.Programmes.FindAsync(Programme.ProgrammeID);

                if (prog != null)
                {
                    _db.Programmes.Remove(prog);
                    await _db.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "DeleteProgramme: db update concurrency error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (DbUpdateException e)
            {
                ErrorMessage = "DeleteProgramme: db update error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (InvalidOperationException e)
            {
                ErrorMessage = "DeleteProgramme: invalid operation error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            catch (Exception e)
            {
                ErrorMessage = "DeleteProgramme: general error: ";
                if (e.Message != null)
                    ErrorMessage += e.Message;
                if (e.InnerException.Message != null)
                    ErrorMessage += e.InnerException.Message;

                return RedirectToPage("MyErrorPage", new { id = Programme.ProgrammeID });
            }
            return RedirectToPage("/ListProgrammes");
        }
    }
}