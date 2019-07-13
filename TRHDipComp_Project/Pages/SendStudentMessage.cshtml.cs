using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace TRHDipComp_Project.Pages
{
    public class SendStudentMessageModel : PageModel
    {
        private readonly CollegeDbContext _db;

        // SupportsGet = true. Necessary to pass a value to the server via OnGet. Is a security 
        // compromise
        [BindProperty(SupportsGet = true)]
        public string ProgrammeID { get; set; } = "";

        private MessageManager msgmgr;

        [BindProperty]
        public IEnumerable<Programme> ProgrammesFound { get; set; }

        [BindProperty]
        public IEnumerable<Programme> Programmes { get; set; }

        [BindProperty]
        public IList<Student> StudentList { get; private set; }

        [BindProperty]
        public IList<Student> StudentsInProgramme { get; set; } = new List<Student>();

        [BindProperty]
        public IList<string> SelectedStudentIDsInProgramme { get; set; } = new List<string>();

        [BindProperty]
        [Display(Name = "Subject (Email only, 100 characters max)")]
        [StringLength(100, MinimumLength = 0)]
        public string Subject { get; set; } = "";

        [BindProperty]
        [Display(Name = "Message content (Email: 500 characters max; SMS: 125 characters max)")]
        [StringLength(500, MinimumLength = 0)]
        public string Message { get; set; } = "";

        [BindProperty]
        [Display(Name = "Send SMS message")]
        public bool SendSMSMessage { get; set; } = false;

        [BindProperty]
        [Display(Name = "Send Email message")]
        public bool SendEmailMessage { get; set; } = false;

        public SendStudentMessageModel(CollegeDbContext db)
        {
            _db = db;
            msgmgr = new MessageManager();
        }

        public async Task OnGetAsync()
        {
            //get list of Students
            StudentList = await _db.Students.AsNoTracking().ToListAsync();
            Programmes = await _db.Programmes.AsNoTracking().ToListAsync();

            if ((ProgrammeID.Length == 0) || (ProgrammeID == "All"))
            {
                ProgrammesFound = Programmes.Select(p => p);
            }
            else
            {
                ProgrammesFound = Programmes.Where(p => p.ProgrammeID == ProgrammeID)
                                            .Select(p => p);
            }

            if (ProgrammesFound.Count() != 0)
            {
                foreach (var programme in ProgrammesFound)
                {
                    var students = StudentList.Where(s => s.ProgrammeID == programme.ProgrammeID)
                                              .Select(s => s);
                    {
                        foreach (var stud in students)
                        {
                            StudentsInProgramme.Add(stud);
                        }
                    }
                }
            }
            else
            {
                foreach (var stud in StudentList)
                {
                    StudentsInProgramme.Add(stud);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                StudentList = await _db.Students.AsNoTracking().ToListAsync();

                foreach (var studID in SelectedStudentIDsInProgramme)
                {
                    var students = StudentList.Where(s => s.StudentID == studID)
                                              .Select(s => s);

                    var student = students.First();

                    if (SendSMSMessage)
                    {
                        msgmgr.SendSMSMessage(student.MobilePhoneNumber, Message);
                    }
                    if (SendEmailMessage)
                    {
                        msgmgr.SendEmailMessage("randles.tom@gmail.com",
                                                student.EmailAddress,
                                                Subject,
                                                Message,
                                                "").Wait();
                    }
                }
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}