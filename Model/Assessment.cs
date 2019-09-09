using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class Assessment
    {
#region properties
        // Assessment ID - Primary Key
        [Key]
        [Required(ErrorMessage = ("Assessment ID is required"))]
        [Display(Name = "Assessment ID")]
        [StringLength(6, ErrorMessage="Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ConcurrencyCheck]
        public string AssessmentID { get; set; }

        // Assessment name
        [Required(ErrorMessage = "Assessment name is required")]
        [Display(Name = "Assessment name")]
        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        [RegularExpression(@"[\w\s\.\,\-]{3,30}", ErrorMessage = "Requires between 3 and 30 characters. Space, periods, hyphens allowed.")]
        public string AssessmentName { get; set; } = "";

        // Assessment description - optional
        [Display(Name = "Assessment description")]
        [StringLength(200, ErrorMessage = "No more than 200 characters")]
        public string AssessmentDescription { get; set; } = "";

        // Total marks 
        [Required(ErrorMessage = ("Maximum mark is required"))]
        [Display(Name = "Assessment maximum mark")]
        [Range(0, 300, ErrorMessage ="Maximum mark should be between 0 and 300.")]
        [RegularExpression(@"\d{1,3}", ErrorMessage = "Maximum mark should be whole number between 0 and 300.")]
        public int AssessmentTotalMark { get; set; }

        public enum AssessmentTypeE
        {
            Project,
            Exam
        }

        // Assessment type
        [Required(ErrorMessage = ("Assessment type should be  \"project\" or \"exam\""))]
        [Display(Name = "Assessment type")]
        [EnumDataType(typeof(AssessmentTypeE))]
        public AssessmentTypeE AssessmentType { get; set; } = AssessmentTypeE.Project;

        // Foreign key to Module
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Module")]
        public string ModuleID { get; set; } = "";

        public virtual ICollection<AssessmentResult> AssessmentResults { get; set; }

        #endregion
    }
}
