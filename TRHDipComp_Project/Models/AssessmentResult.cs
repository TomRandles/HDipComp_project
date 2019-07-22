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
        [StringLength(50, ErrorMessage = "No more than 50 characters")]
        [Display(Name = "Assessment Result ID")]
        [RegularExpression(@"[\-\w\.]{10,50}")]
        public string AssessmentResultID { get; set; }

        // Assessment result description - optional
        [Display(Name = "Assessment feedback")]
        [StringLength(100, ErrorMessage = "No more than 100 characters")]
        
        public string AssessmentResultDescription { get; set; } = "";

        // Result mark 
        [Display(Name = "Assessment result (%)")]
        [RegularExpression(@"^\d{1,3}\.{0,1}\d{0,2}$")]
        [Range(0, 100)]
        public double AssessmentResultMark { get; set; } = 0;

        //Foreign Key - Student
        [Required]
        [Display(Name = "Student ID")]
        [MaxLength(7)]
        [RegularExpression(@"[sS]{1}[0-9]{6}")]
        [ForeignKey("Student")]
        [ConcurrencyCheck]
        public string StudentID { get; set; }

        // Foreign Key - Programme ID
        [Required]
        [Display(Name = "Programme ID")]
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("ProgrammeModule")]
        public string ProgrammeID { get; set; }

        [Display(Name = "Assessment date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = ("Assessment date required: format {0:dd-MM-yyyy}"))]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [ConcurrencyCheck]
        public DateTime AssessmentDate { get; set; }

        // Foreign Key - Module ID
        [Required]
        [Display(Name = "Module")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("ProgrammeModule")]
        public string ModuleID { get; set; }

        // Foreign Key - Assessment ID 
        [Required]
        [Display(Name = "Assessment")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ForeignKey("Assessment")]
        [ConcurrencyCheck]
        public string AssessmentID { get; set; }
        
        // Function used to generate a unique and random 6 character ID
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