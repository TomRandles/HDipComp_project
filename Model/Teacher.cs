using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace TRHDipComp_Project.Models
{
    public class Teacher
    {
        [Key]
        [Required(ErrorMessage = ("Teacher ID required"))]
        [Display(Name = "Teacher ID:")]
        [StringLength(7, ErrorMessage = "Must be 7 characters")]
        [RegularExpression(@"[tT]{1}[0-9]{6}", ErrorMessage = "Must be a single \'T\' character followed by 6 digits")]
        [ConcurrencyCheck]
        public string TeacherID { get; set; }

        [Display(Name = "Title:")]
        [RegularExpression(@"[\w\'\-\s\,\.]{1,10}", ErrorMessage = "Between 1 and 10 characters")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = ("First name required"))]
        [Display(Name = "Teacher first name:")]
        [RegularExpression(@"[\w\'\-\s\,\.]{2,20}", ErrorMessage = "Between 2 and 20 characters")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = ("Surname name required"))]
        [Display(Name = "Teacher surname:")]
        [RegularExpression(@"[\w\'\-\s\,\.]{2,20}", ErrorMessage = "Between 2 and 20 characters")]
        public string SurName { get; set; } = "";

        [Required(ErrorMessage = ("Address 1 is required"))]
        [Display(Name = "Address 1:")]
        [RegularExpression(@"[\s\w\-\,\.]{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters")]
        public string AddressOne { get; set; } = "";

        [Required(ErrorMessage = ("Address 2 is required"))]
        [Display(Name = "Address 2:")]
        [RegularExpression(@"[\s\w\-\,\.]{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters")]
        public string AddressTwo { get; set; } = "";

        [Required(ErrorMessage = "Town is required.")]
        [Display(Name = "Town:")]
        [RegularExpression(@"[\s\w\-\,\.\']{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters")]
        public string Town { get; set; } = "";

        [Required(ErrorMessage = ("County is required"))]
        [Display(Name = "County:")]
        [RegularExpression(@"[\s\w\-\,\.]{3,30}", ErrorMessage = "Minimum 3, maximum 30 characters")]
        public string County { get; set; } = "";

        [Required(ErrorMessage = ("Mobile number is required."))]
        [Display(Name = "Mobile number:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[\+]{1}[1-9]{1,3}[0-9]{9}", ErrorMessage = "[+][country code][area code][number] 12-14 numeric characters; no spaces or hyphens")]
        public string MobilePhoneNumber { get; set; } = "";

        [Required(ErrorMessage = ("Email address is required. Format name@emailaddress.com "))]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = "";

        [Required(ErrorMessage = "Emergency number is required.")]
        [Display(Name = "Emergency contact number:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[\+]{1}[1-9]{1,3}[0-9]{9}", ErrorMessage = "[+][country code][area code][number] 12-14 numeric characters; no spaces or hyphens")]
        public string EmergencyMobilePhoneNumber { get; set; } = "";

        // PPS is 8 numeric characters
        [Required(ErrorMessage = ("PPS is 7 numbers and 1 or 2 characters"))]
        [Display(Name = "Teacher PPS number:")]
        [StringLength(10)]
        [RegularExpression(@"[0-9]{7}[A-Z]{1,2}", ErrorMessage = ("PPS is 7 numbers and 1 or 2 characters"))]
        public string TeacherPPS { get; set; } = "";

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

        [Required(ErrorMessage = ("Gender should be \"Male\" or \"Female\""))]
        [Display(Name = "Gender:")]
        [EnumDataType(typeof(GenderTypeE))]
        public GenderTypeE GenderType { get; set; } = GenderTypeE.Female;

        //Either Full time or Part Time  
        [Required(ErrorMessage = ("Enter either \"Fulltime\" or \"Parttime\""))]
        [Display(Name = "Fulltime / parttime:")]
        [EnumDataType(typeof(FullOrPartTimeE))]
        public FullOrPartTimeE FullOrPartTime { get; set; } = FullOrPartTimeE.Fulltime;

        public byte[] TeacherImage { get; set; }
                
        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }

        public string GetRandomID()
        {
            Random r = new Random();

            return 'T' + r.Next(100_000, 999_999).ToString();
        }

        // Override ToString to provide the Teacher name as a single string
        public override string ToString()
        {
            return $"{Title} {FirstName} {SurName}";
        }
    }
}