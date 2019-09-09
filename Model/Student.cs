using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRHDipComp_Project.Models.Validation;

namespace TRHDipComp_Project.Models
{
    public class Student
    {
        #region properties
        [Key]
        [Required(ErrorMessage = ("Student ID required"))]
        [Display(Name = "Student ID:")]
        [StringLength(7, ErrorMessage = "Must be 7 characters")]
        [RegularExpression(@"[sS]{1}[0-9]{6}", ErrorMessage = "Must be a single \'S\' character followed by 6 digits")]
        [ConcurrencyCheck]
        public string StudentID { get; set; }

        [Required(ErrorMessage = ("First name required"))]
        [Display(Name = "Student first name:")]
        [RegularExpression(@"[\w\'\-\s\,\.]{2,20}", ErrorMessage = "Between 2 and 20 characters. Hyphen, comma, period, apostrophe allowed.")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = ("Surname name required"))]
        [Display(Name = "Student surname:")]
        [RegularExpression(@"[\w\'\-\s\,\.]{2,20}", ErrorMessage = "Between 2 and 20 characters. Hyphen, comma, period, apostrophe allowed.")]
        public string SurName { get; set; } = "";

        [Required(ErrorMessage = ("Address 1 is required"))]
        [Display(Name = "Address 1:")]
        [RegularExpression(@"[\s\w\-\,\.]{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters. Hyphen, comma, period, apostrophe allowed.")]
        public string AddressOne { get; set; } = "";

        [Required(ErrorMessage = ("Address 2 is required"))]
        [Display(Name = "Address 2:")]
        [RegularExpression(@"[\s\w\-\,\.]{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters. Hyphen, comma, period, apostrophe allowed.")]
        public string AddressTwo { get; set; } = "";

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Town:")]
        [RegularExpression(@"[\s\w\-\,\.\']{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters. Hyphen, comma, period, apostrophe allowed.")]
        public string Town { get; set; } = "";

        [Required(ErrorMessage = ("County is required"))]
        [Display(Name = "County:")]
        [RegularExpression(@"[\s\w\-\,\.\']{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters. Hyphen, comma, period, apostrophe allowed.")]
        public string County { get; set; } = "";

        [Required(ErrorMessage = ("Mobile number is required."))]
        [Display(Name = "Mobile number:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[\+]{1}[0-9]{1,3}[0-9]{9}", ErrorMessage = "[+][country code][area code][number] 10-12 numeric characters; no spaces or hyphens")]
        public string MobilePhoneNumber { get; set; } = "";

        [Required(ErrorMessage = ("Email address required: Format is name@emailaddress.com "))]
        [Display(Name = "Email:")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Format is name@emailaddress.com")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = "";

        [Required(ErrorMessage = "Emergency number is required.")]
        [Display(Name = "Emergency contact number:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[\+]{1}[0-9]{1,3}[0-9]{9}", ErrorMessage = "[+][country code][area code][number] 10-12 numeric characters; no spaces or hyphens")]
        public string EmergencyMobilePhoneNumber { get; set; } = "";

        // PPS is 8 numeric characters
        [Required(ErrorMessage = "PPS is required")]
        [Display(Name = "Student PPS number:")]
        [RegularExpression(@"[0-9]{7}[A-Za-z]{1,2}", ErrorMessage = ("PPS is 7 numbers followed by 1 or 2 characters"))]
        public string StudentPPS { get; set; } = "";

        // Program fee - optional - can be paid later
        [Display(Name = "Programme fee paid:")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"[0-9]{0,5}\.{0,1}[0-9]{0,2}", ErrorMessage = "Must be a currency value between 0.00 and 99999.00") ]
        [StudentProgrammeFee]
        public decimal ProgrammeFeePaid { get; set; } = 0;

        [Required(ErrorMessage = ("Student date of birth required. Format DD-MM-YYYY"))]
        [Display(Name = "Student date of birth:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        // StudentDateOfBirth - custom validation - check student's age is between 18 and 60
        [StudentDateOfBirth]
        public DateTime DateOfBirth { get; set; }

        public enum GenderTypeE
        {
            Male,
            Female
        }

        public enum FullOrPartTimeE
        {
            Fulltime,
            Parttime
        }

        [Required(ErrorMessage = ("Gender should be  \"male\" or \"female\""))]
        [Display(Name = "Gender:")]
        [EnumDataType(typeof(GenderTypeE))]
        public GenderTypeE GenderType { get; set; } = GenderTypeE.Female;

        //Either Full time or Part Time  
        [Required(ErrorMessage = ("Enter either \"fulltime\" or \"parttime\""))]
        [Display(Name = "Fulltime / parttime:")]
        [EnumDataType(typeof(FullOrPartTimeE))]
        public FullOrPartTimeE FullOrPartTime { get; set; } = FullOrPartTimeE.Fulltime;

        public byte[] StudentImage { get; set; }

        // Student programme of study - Foreign Key        
        [Display(Name = "Student Programme ID:")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}", ErrorMessage = "Programme ID must be six-character alphanumeric string")]
        [ForeignKey("Programme")]
        public string ProgrammeID { get; set; } = "";

        public virtual ICollection<AssessmentResult> AssessmentResults { get; set; }

        #endregion

        public string GetRandomID()
        {
            string studentID;
            Random r = new Random();

            studentID = 'S' + r.Next(100_000, 999_999).ToString();
            return studentID;
        }

        // Override ToString to provide the student name as a single string
        public override string ToString()
        {
            return $"{FirstName} {SurName}";
        }
    }
}