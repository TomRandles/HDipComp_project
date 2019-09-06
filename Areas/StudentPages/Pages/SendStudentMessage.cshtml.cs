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
using TRHDipComp_Project.Models.Database;
using TRHDipComp_Project.Models.Messaging;

namespace TRHDipComp_Project.Areas.StudentPages.Pages
{
    public class SendStudentMessageModel : PageModel
    {
        #region db_properties_ctr
        private readonly CollegeDbContext _db;

        private readonly IConfiguration _configuration;

        // SupportsGet = true. Necessary to pass a value to the server via OnGet. Is a security 
        // compromise
        [BindProperty(SupportsGet = true)]
        public string ProgrammeID { get; set; } = "";

        [TempData]
        public string MessageResults { get; set; }

      
        // Message manager object to handle both SMS and email functions 
        private readonly MessageManager msgMgr;

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

        private readonly string accountSid;
        private readonly string authToken; 
        private readonly string myTwilioPhoneNumber;
        private readonly string mySourceEmailAddress;

        public SendStudentMessageModel(CollegeDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
            
            accountSid = _configuration["AppSettings:TwilioAccountSID"];
            authToken = _configuration["AppSettings:TwilioAuthToken"];
            myTwilioPhoneNumber = _configuration["AppSettings:MyTwilioPhoneNumber"];
            mySourceEmailAddress = _configuration["AppSettings:SENDGRID_Default_Source_Email_Address"];

            msgMgr = new MessageManager(accountSid,
                                        authToken);
        }
        #endregion

        #region get
        public async Task OnGetAsync()
        {
            //get list of Students and Programmes
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
        #endregion

        #region post
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                StudentsList = await _db.Students.AsNoTracking().ToListAsync();

                int studentCounter = 1;
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

                            MessageResults += $"{studentCounter}. SMS to {student.ToString()},mobile: {student.MobilePhoneNumber}, " +
                                              $"sent on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()} was sent successfully." +
                                              $" {Environment.NewLine}";
                        }
                        catch (TwilioException e)
                        { 
                            MessageResults += $"{studentCounter}. SMS Error, student: {student.ToString()}, mobile number: {student.MobilePhoneNumber}. {Environment.NewLine}";
                            if (e.Message != null)
                                MessageResults += e.Message;
                            if ((e.InnerException != null) && (e.InnerException.Message != null))
                                MessageResults += e.InnerException.Message;
                            MessageResults += Environment.NewLine;
                        }
                    }
                    if (SendEmailMessage)
                    {
                        try
                        {
                            // No HTML content sent for now
                            string htmlContent = "";
                            msgMgr.SendEmailMessage(mySourceEmailAddress,
                                                    student.EmailAddress,
                                                    Subject,
                                                    Message,
                                                    htmlContent).Wait();
                            MessageResults += $"{studentCounter}. Email  to {student.ToString()} ,email : {student.EmailAddress}, " +
                                              $"sent on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()} was sent successfully." +
                                              $"{Environment.NewLine}";
                        }
                        catch (Exception e)
                        {
                            MessageResults += $"{studentCounter}. EMail Error, student: {student.ToString()}, email: {student.EmailAddress}, " +
                                $"sent on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()} {Environment.NewLine}";
                            if (e.Message != null)
                                MessageResults += e.Message;
                            if ((e.InnerException != null) && (e.InnerException.Message != null))
                                MessageResults += e.InnerException.Message;
                            MessageResults += Environment.NewLine;
                        }
                    }
                    studentCounter++;
                }
               
                return RedirectToPage("/SendStudentMessageResults", new { area = "StudentPages" }); 

            }
            else
            {
                return Page();
            }
        }
        #endregion
    }
}