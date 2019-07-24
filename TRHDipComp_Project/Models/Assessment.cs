using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class Assessment
    {
        // Assessment ID - Primary Key
        [Key]
        [Required(ErrorMessage = ("Assessment ID required"))]
        [Display(Name = "Assessment ID")]
        [StringLength(6, ErrorMessage="Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ConcurrencyCheck]
        public string AssessmentID { get; set; }

        // Assessment name
        [Required]
        [Display(Name = "Assessment name")]
        [StringLength(30, ErrorMessage = "No more than 30 characters")]
        public string AssessmentName { get; set; } = "";

        // Assessment description - optional
        [Display(Name = "Assessment description")]
        [StringLength(100, ErrorMessage = "No more than 100 characters")]
        public string AssessmentDescription { get; set; } = "";

        // Total marks 
        [Required]
        [Display(Name = "Assessment maximum mark")]
        [RegularExpression(@"\d{1,3}")]
        public int AssessmentTotalMark { get; set; } = 0;

        public enum AssessmentTypeE
        {
            project,
            exam
        }

        // Assessment type
        [Required(ErrorMessage = ("Assessment type should be  \"project\" or \"exam\""))]
        [Display(Name = "Assessment type")]
        [EnumDataType(typeof(AssessmentTypeE))]
        public AssessmentTypeE AssessmentType { get; set; } = AssessmentTypeE.project;

        // Foreign key to Module
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Module")]
        public string ModuleID { get; set; } = "";

        public virtual ICollection<AssessmentResult> AssessmentResults { get; set; }
    }
}
