using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class AssessmentResult
    {
        // Assessment Result ID - Primary Key
        [Key]
        [Required(ErrorMessage = ("Assessment result ID must be 6 alphanumeric characters"))]
        [Display(Name = "Assessment Result ID")]
        [StringLength(6)]
        [RegularExpression(@"\w{6}")]
        public string AssessmentResultID { get; set; }

        // Assessment description
        [Display(Name = "Assessment results description")]
        [StringLength(50)]
        [RegularExpression(@"[\s\w-\,\.]{0,50}")]
        public string AssessmentResultDescription { get; set; } = "";

        // Result mark 
        [Display(Name = "Assessment result mark")]
        [RegularExpression(@"\w{1,3}")]
        public int AssessmentResultMark { get; set; } = 0;

        //Foreign Key - Student   
        [Display(Name = "Student ID")]
        [MaxLength(7)]
        [RegularExpression(@"[gG]{1}[0-9]{6}")]
        [ForeignKey("Student")]
        public string StudentID { get; set; }

        // Foreign Key - Programme ID 
        [Display(Name = "Programme ID")]
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("ProgrammeModule")]
        public string ProgrammeID { get; set; }

        // Foreign Key - Module ID
        [Display(Name = "Module ID")]
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("ProgrammeModule")]
        public string ModuleID { get; set; }

        // Foreign Key - Assessment ID 
        [Display(Name = "Assessment ID")]
        [StringLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Assessment")]
        public string AssessmentID { get; set; }
    }
}