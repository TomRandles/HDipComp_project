using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRHDipComp_Project.Models.Validation;

namespace TRHDipComp_Project.Models
{
    public class AssessmentResult
    {
        #region properties
        // Assessment Result ID - Primary Key
        [Key]
        [Display(Name = "Assessment Result ID")]
        [RegularExpression(@"[\-\w\.]{10,50}", ErrorMessage = "Between 10 and 50 characters. Underscore, hypens, periods allowed.")]
        [ConcurrencyCheck]
        public string AssessmentResultID { get; set; }


        // Assessment result description - optional
        [Display(Name = "Assessment feedback")]
        [StringLength(200, ErrorMessage = "No more than 200 characters")]
        public string AssessmentResultDescription { get; set; } = "";

        // Result mark 
        [Display(Name = "Assessment result")]
        [RegularExpression(@"^\d{1,3}\.{0,1}\d{0,2}$", ErrorMessage = "Requires a numeric value with a max of two decimal places.")]
        // Custom validation rulw for AssessmentResult
        [AssessmentResultMark]
        [Range(0, 100, ErrorMessage ="Assessment result should be between 0 and 100")]
        public double AssessmentResultMark { get; set; } = 0;

        //Foreign Key - Student
        [Required(ErrorMessage = "Student ID is required")]
        [Display(Name = "Student ID")]
        [StringLength(7, ErrorMessage = "Must be 7 characters")]
        [RegularExpression(@"[sS]{1}[0-9]{6}", ErrorMessage = "Must be 6 alphanumeric characters.")]
        [ForeignKey("Student")]
        public string StudentID { get; set; }

        // Foreign Key - Programme ID
        [Required (ErrorMessage = "Programme ID is required")]
        [Display(Name = "Programme ID")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 alphanumeric characters.")]
        [ForeignKey("ProgrammeModule")]
        public string ProgrammeID { get; set; }

        [Required(ErrorMessage = ("Assessment date required: format {0:dd-MM-yyyy}"))]
        [Display(Name = "Assessment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        //AssessmentDate - custom validation - check that date is within 6 months in the past and not in the future
        [AssessmentDate]
        public DateTime AssessmentDate { get; set; }

        // Foreign Key - Module ID
        [Required (ErrorMessage = "Module ID is required")]
        [Display(Name = "Module")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 alphanumeric characters.")]
        [ForeignKey("ProgrammeModule")]
        public string ModuleID { get; set; }

        // Foreign Key - Assessment ID 
        [Required(ErrorMessage = "Assessment ID is required")]
        [Display(Name = "Assessment")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 alphanumeric characters.")]
        [ForeignKey("Assessment")]
        public string AssessmentID { get; set; }

        #endregion
    }
}