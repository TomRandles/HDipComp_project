using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRHDipComp_Project.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = ("Student ID must be a single character followed by 6 digits"))]
        [Display(Name = "Student ID")]
        [RegularExpression(@"[gG]{1}[0-9]{6}")]
        public string StudentID { get; set; }

        [Required(ErrorMessage = ("First name is at least 2 characters"))]
        [Display(Name = "Student first name")]
        [RegularExpression(@"[\w\'-]{2,20}")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = ("Surname name is at least 2 characters"))]
        [Display(Name = "Student surname")]
        [RegularExpression(@"[\w\'-]{2,20}")]
        public string SurName { get; set; } = "";

        [Required(ErrorMessage = ("Address 1 is at least 3 alpha-numeric characters"))]
        [Display(Name = "Address 1")]
        [RegularExpression(@"[\s\w-\,\.]{3,30}")]
        public string AddressOne { get; set; } = "";

        [Required(ErrorMessage = ("Address 2 is at least 3 alpha-numeric characters"))]
        [Display(Name = "Address 2")]
        [RegularExpression(@"[\s\w-\,\.]{3,30}")]
        public string AddressTwo { get; set; } = "";

        [Required(ErrorMessage = ("Address is at least 3 alpha-numeric characters"))]
        [Display(Name = "Town")]
        [RegularExpression(@"[\s\w-\,\.]{3,30}")]
        public string Town { get; set; } = "";

        [Required(ErrorMessage = ("County is at least 4 alpha-numeric characters"))]
        [Display(Name = "County")]
        [RegularExpression(@"[\s\w-\,\.]{4,30}")]
        public string County { get; set; } = "";

        [Required(ErrorMessage = ("Mobile number is exclusively 10-12 numeric characters; no spaces or hyphens"))]
        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[0-9]{10,12}")]
        public string MobilePhoneNumber { get; set; } = "";

        [Required(ErrorMessage = ("Email address is name@emailaddress.com "))]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = "";

        [Required(ErrorMessage = ("Mobile number is exclusively 10-12 numeric characters; no spaces or hyphens"))]
        [Display(Name = "Emergency contact mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[0-9]{10,12}")]
        public string EmergencyMobilePhoneNumber { get; set; } = "";

        // PPS is 9 numeric characters
        [Required(ErrorMessage = ("PPS is 7 numbers and 1 or 2 characters"))]
        [Display(Name = "Student PPS number")]
        [RegularExpression(@"[0-9]{7}[A-Z]{1,2}")]
        public string StudentPPS { get; set; } = "";

        [Required(ErrorMessage = ("Student date of birth incorrect. Format DD/MM/YYYY"))]
        [Display(Name = "Student date of birth")]
        [DataType(DataType.Date)]
        // [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        public enum Gender
        {
            male,
            female
        }

        public enum FullOrPartTimeE
        {
            fulltime,
            parttime
        }

        [Required(ErrorMessage = ("Gender should be  \"male\" or \"female\""))]
        [Display(Name = "Student gender")]
        [EnumDataType(typeof(Gender))]
        public Gender GenderType { get; set; } = Gender.female;

        //Either Full time or Part Time  
        [Required(ErrorMessage = ("Enter either \"fulltime\" or \"parttime\""))]
        [Display(Name = "Fulltime or parttime")]
        [EnumDataType(typeof(FullOrPartTimeE))]
        public FullOrPartTimeE FullOrPartTime { get; set; } = FullOrPartTimeE.fulltime;

        // Student programme of study - Foreign Key        
        [Display(Name = "Student Programme ID")]
        
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Programme")]
        public string StudentProgrammeID { get; set; } = ""; 

    }
}
