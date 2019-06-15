using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        [Required(ErrorMessage = ("Assessment name is at least 6 characters"))]
        [Display(Name = "Assessment name")]
        [StringLength(20)]
        [RegularExpression(@"[\w\s\.\,]{6,20}")]
        public string AssessmentName { get; set; } = "";

        // Assessment description
        [Display(Name = "Assessment description")]
        [StringLength(50)]
        [RegularExpression(@"[\s\w-\,\.]{0,50}")]
        public string AssessmentDescription { get; set; } = "";

        // Total marks 
        [Display(Name = "Assessment total marks")]
        [RegularExpression(@"\w{1,3}")]
        public int AssessmentTotalMarks { get; set; } = 0;

        public enum AssessmentTypeE
        {
            project,
            exam
        }

        [Required(ErrorMessage = ("Assessment type should be  \"project\" or \"exam\""))]
        [Display(Name = "Assessment")]
        [EnumDataType(typeof(AssessmentTypeE))]
        public AssessmentTypeE AssessmentType { get; set; } = AssessmentTypeE.project;

        [StringLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Module")]
        public string AssessmentModuleID { get; set; } = "";
    }
}
