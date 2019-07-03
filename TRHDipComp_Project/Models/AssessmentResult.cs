using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TRHDipComp_Project.Models
{
    public class AssessmentResult
    {

        // Assessment Result ID - Primary Key
        [Key]
        [MaxLength(50)]
        public string AssessmentResultID { get; set; }

        // Assessment description
        [Display(Name = "Assessment feedback")]
        [StringLength(100)]
        [RegularExpression(@"[\s\w-\,\.!]{0,100}")]
        public string AssessmentResultDescription { get; set; } = "";

        // Result mark 
        [Display(Name = "Assessment result (%)")]
        [RegularExpression(@"^\d{1,3}\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public double AssessmentResultMark { get; set; } = 0;

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

        //
        [Display(Name = "Assessment Date")]
        [Required(ErrorMessage = ("Assessment date incorrect. Format DD/MM/YYYY"))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AssessmentDate { get; set; }

        // Foreign Key - Module ID
        [Display(Name = "Module")]
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("ProgrammeModule")]
        public string ModuleID { get; set; }

        // Foreign Key - Assessment ID 
        [Display(Name = "Assessment")]
        [StringLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Assessment")]
        public string AssessmentID { get; set; }
        
        private string GetRandomID()
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < 6; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().ToUpper();
        }
    }
}