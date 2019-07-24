using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRHDipComp_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Twilio.Exceptions;
using Microsoft.Extensions.Configuration;

namespace TRHDipComp_Project.Pages
{
    public class SendStudentMessageModel : PageModel
    {
        private readonly CollegeDbContext _db;

        private readonly IConfiguration _configuration;

        // SupportsGet = true. Necessary to pass a value to the server via OnGet. Is a security 
        // compromise
        [BindProperty(SupportsGet = true)]
        public string ProgrammeID { get; set; } = "";

        // Error message management property
        [TempData]
        public string ErrorMessage { get; set; } = "";

        // Message manager object to handle both SMS and email functions 
        private MessageManager msgMgr;

        // Filtered programmmes
        [BindProperty]
        public IList<Programme> ProgrammesFound { get; set; }

        // Programmes in the system
        [BindProperty]
        public IList<Programme> ProgrammesList { get; set; }

        // Registered students
        [BindProperty]
        public IList<Student> StudentsList { get; private set; }

        // Students in a particular programme
        [BindProperty]
        public IList<Student> StudentsInProgramme { get; set; } = new List<Student>();

        // Students in a particular programme that have been selected
        [BindProperty]
        public IList<string> SelectedStudentIDsInProgramme { get; set; } = new List<string>();

        [BindProperty]
        [Display(Name = "Subject (Email only, 100 characters max)")]
        [StringLength(100, MinimumLength = 0, ErrorMessage ="100 characters max.")]
        public string Subject { get; set; } = "";

        [BindProperty]
        [Display(Name = "Message content (Email: 500 characters max; SMS: 125 characters max)")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "500 characters max.")]
        public string Message { get; set; } = "";

        [BindProperty]
        [Display(Name = "Send SMS message")]
        public bool SendSMSMessage { get; set; } = false;

        [BindProperty]
        [Display(Name = "Send Email message")]
        public bool SendEmailMessage { get; set; } = false;

        private string accountSid;
        private string authToken; 
        private string myTwilioPhoneNumber;

        public SendStudentMessageModel(CollegeDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            
            accountSid = _configuration["AppSettings:TwilioAccountSID"];
            authToken = _configuration["AppSettings:TwilioAuthToken"];
            myTwilioPhoneNumber = _configuration["AppSettings:MyTwilioPhoneNumber"];

            msgMgr = new MessageManager(accountSid,
                                        authToken);
        }

        public async Task OnGetAsync()
        {
            //get list of Students
            StudentsList = await _db.Students.AsNoTracking().ToListAsync();
            ProgrammesList = await _db.Programmes.AsNoTracking().ToListAsync();

            if ((ProgrammeID.Length == 0) || (ProgrammeID == "All"))
            {
                ProgrammesFound = ProgrammesList.Select(p => p).ToList();
            }
            else
            {
                ProgrammesFound = ProgrammesList.Where(p => p.ProgrammeID == ProgrammeID)
                                            .Select(p => p).ToList();
            }

            if (ProgrammesFound.Count() != 0)
            {
                foreach (var programme in ProgrammesFound)
                {
                    var students = StudentsList.Where(s => s.ProgrammeID == programme.ProgrammeID)
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
                foreach (var stud in StudentsList)
                {
                    StudentsInProgramme.Add(stud);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                StudentsList = await _db.Students.AsNoTracking().ToListAsync();

                foreach (var studID in SelectedStudentIDsInProgramme)
                {
                    var student = StudentsList.Where(s => s.StudentID == studID)
                                              .Select(s => s)
                                              .FirstOrDefault();

                    if (SendSMSMessage)
                    {
                        try
                        {
                            msgMgr.SendSMSMessage(student.MobilePhoneNumber, 
                                Message,
                                myTwilioPhoneNumber
                                );
                        }
                        catch (TwilioException e)
                        {
                            if (e.Message != null)
                                ErrorMessage = e.Message;
                            if ((e.InnerException != null) && (e.InnerException.Message != null))
                                ErrorMessage += e.InnerException.Message;
                            RedirectToPage("MyErrorPage", new { id = student.StudentID });
                        }
                    }
                    if (SendEmailMessage)
                    {
                        try
                        {
                            msgMgr.SendEmailMessage("randles.tom@gmail.com",
                                                    student.EmailAddress,
                                                    Subject,
                                                    Message,
                                                    "").Wait();
                        }
                        catch (Exception e)
                        {
                            if (e.Message != null)
                                ErrorMessage = e.Message;
                            if ((e.InnerException != null) && (e.InnerException.Message != null)) 
                                ErrorMessage += e.InnerException.Message;

                            RedirectToPage("MyErrorPage", new { id = student.StudentID });
                        }
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