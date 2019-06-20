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
        [MaxLength(7)]
        [RegularExpression(@"[gG]{1}[0-9]{6}")]
        public string StudentID { get; set; }

        [Required(ErrorMessage = ("First name is at least 2 characters"))]
        [Display(Name = "Student first name")]
        [MaxLength(20)]
        [RegularExpression(@"[\w\'-]{2,20}")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = ("Surname name is at least 2 characters"))]
        [Display(Name = "Student surname")]
        [MaxLength(20)]
        [RegularExpression(@"[\w\'-]{2,20}")]
        public string SurName { get; set; } = "";

        [Required(ErrorMessage = ("Address 1 is at least 3 alpha-numeric characters"))]
        [Display(Name = "Address 1")]
        [MaxLength(30)]
        [RegularExpression(@"[\s\w-\,\.]{3,30}")]
        public string AddressOne { get; set; } = "";

        [Required(ErrorMessage = ("Address 2 is at least 3 alpha-numeric characters"))]
        [Display(Name = "Address 2")]
        [MaxLength(30)]
        [RegularExpression(@"[\s\w-\,\.]{3,30}")]
        public string AddressTwo { get; set; } = "";

        [Required(ErrorMessage = ("Address is at least 3 alpha-numeric characters"))]
        [Display(Name = "Town")]
        [MaxLength(30)]
        [RegularExpression(@"[\s\w-\,\.]{3,30}")]
        public string Town { get; set; } = "";

        [Required(ErrorMessage = ("County is at least 4 alpha-numeric characters"))]
        [Display(Name = "County")]
        [MaxLength(30)]
        [RegularExpression(@"[\s\w-\,\.]{4,30}")]
        public string County { get; set; } = "";

        [Required(ErrorMessage = ("Mobile number is exclusively 10-12 numeric characters; no spaces or hyphens"))]
        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(12)]
        [RegularExpression(@"[0-9]{10,12}")]
        public string MobilePhoneNumber { get; set; } = "";

        [Required(ErrorMessage = ("Email address is name@emailaddress.com "))]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = "";

        [Required(ErrorMessage = ("Mobile number is exclusively 10-12 numeric characters; no spaces or hyphens"))]
        [Display(Name = "Emergency contact mobile number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(12)]
        [RegularExpression(@"[0-9]{10,12}")]
        public string EmergencyMobilePhoneNumber { get; set; } = "";

        // PPS is 8 numeric characters
        [Required(ErrorMessage = ("PPS is 7 numbers and 1 or 2 characters"))]
        [Display(Name = "Student PPS number")]
        [MaxLength(8)]
        [RegularExpression(@"[0-9]{7}[A-Z]{1,2}")]
        public string StudentPPS { get; set; } = "";

        // 
        [Display(Name = "Programme fee paid")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"\d{0,5}\.{0,1}\d{0,2}")]
        public decimal ProgrammeFeePaid { get; set; } = 0;

        [Required(ErrorMessage = ("Student date of birth incorrect. Format DD/MM/YYYY"))]
        [Display(Name = "Student date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        // [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        public enum GenderTypeE
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
        [EnumDataType(typeof(GenderTypeE))]
        public GenderTypeE GenderType { get; set; } = GenderTypeE.female;

        //Either Full time or Part Time  
        [Required(ErrorMessage = ("Enter either \"fulltime\" or \"parttime\""))]
        [Display(Name = "Fulltime or parttime")]
        [EnumDataType(typeof(FullOrPartTimeE))]
        public FullOrPartTimeE FullOrPartTime { get; set; } = FullOrPartTimeE.fulltime;

        // Student programme of study - Foreign Key        
        [Display(Name = "Student Programme ID")]
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Programme")]
        public string ProgrammeID { get; set; } = "";

        public virtual ICollection<AssessmentResult> AssessmentResults { get; set; }
    }
}
