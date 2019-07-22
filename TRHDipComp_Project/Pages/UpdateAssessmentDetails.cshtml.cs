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
    public class UpdateAssessmentDetailsModel : PageModel
    {
        private readonly CollegeDbContext _db;

        [TempData]
        public string ErrorMessage { get; set; }

        public UpdateAssessmentDetailsModel(CollegeDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IList<Module> ModuleListOptions { get; private set; }

        [BindProperty]
        public Assessment Assessment { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            ModuleListOptions = await _db.Modules.AsNoTracking().ToListAsync();

            Assessment = await _db.Assessments.FindAsync(id);

            if (Assessment == null)
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

            _db.Attach(Assessment).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                ErrorMessage = "Db update concurrency error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
            } catch (DbUpdateException e)
            {
                ErrorMessage = "Db update error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
            }
            catch (Exception e)
            {
                ErrorMessage = "General error: " + e.Message + " " + e.InnerException.Message;
                return RedirectToPage("MyErrorPage", new { id = Assessment.AssessmentID });
            }

            return RedirectToPage("/ShowAssessmentDetails");
        }
    }
}