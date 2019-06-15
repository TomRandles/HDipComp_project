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
    public class CreateProgrammeModel : PageModel
    {
        private readonly CollegeDbContext _db;
        public string message { get; set; } = "";

        [BindProperty]
        public Programme Programme { get; set; } = new Programme();


        public CreateProgrammeModel(CollegeDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                message += " ModelState is Valid";

                _db.Programmes.Add(Programme);
                await _db.SaveChangesAsync();

                return RedirectToPage("ShowProgrammeDetails", new { id = Programme.ProgrammeID });
            }
            else
            {
                message += " ModelState is InValid";
                return Page();
            }
        }
    }
}