using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class Assessment
    {
        // Assessment ID - Primary Key
        [Key]
        [Required(ErrorMessage = ("Assessment ID must be 6 alphanumeric characters"))]
        [Display(Name = "Assessment ID")]
        [StringLength(6)]
        [RegularExpression(@"\w{6}")]
        public string AssessmentID { get; set; }

        // Assessment name
        [Required]
        [Display(Name = "Assessment name")]
        [StringLength(30)]
        public string AssessmentName { get; set; } = "";

        // Assessment description
        [Display(Name = "Assessment description")]
        [StringLength(100)]
        [RegularExpression(@"[\s\w-\,\.\!]{0,100}")]
        public string AssessmentDescription { get; set; } = "";

        // Total marks 
        [Display(Name = "Assessment total mark")]
        [RegularExpression(@"\d{1,3}")]
        public int AssessmentTotalMark { get; set; } = 0;

        public enum AssessmentTypeE
        {
            project,
            exam
        }

        [Required(ErrorMessage = ("Assessment type should be  \"project\" or \"exam\""))]
        [Display(Name = "Assessment type")]
        [EnumDataType(typeof(AssessmentTypeE))]
        public AssessmentTypeE AssessmentType { get; set; } = AssessmentTypeE.project;

        [StringLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Module")]
        public string ModuleID { get; set; } = "";

        public virtual ICollection<AssessmentResult> AssessmentResults { get; set; }
    }
}
