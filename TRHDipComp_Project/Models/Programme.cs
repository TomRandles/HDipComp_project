using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class Programme
    {
        // Programme ID - Primary Key
        [Key]
        [Required(ErrorMessage = ("Programme ID must be 6 alphanumeric characters"))]
        [Display(Name = "Programme ID")]
        [RegularExpression(@"\w{6}")]
        public string ProgrammeID { get; set; }

        // Programme name
        [Required(ErrorMessage = ("Programme name is at least 6 characters"))]
        [Display(Name = "Programme name")]
        [RegularExpression(@"[\w\s\.\,]{6,20}")]
        public string ProgrammeName { get; set; } = "";

        // Programme description
        [Display(Name = "Programme description")]
        [RegularExpression(@"[\s\w-\,\.]{0,50}")]
        public string ProgrammeDescription { get; set; } = "";

        // QQI level
        [Display(Name = "Programme QQI level")]
        [RegularExpression(@"\w{1}")]
        public int ProgrammeQQILevel { get; set; } = 5;

        // Credits 
        [Display(Name = "Programme Credits")]
        [RegularExpression(@"\w{1,3}")]
        public int ProgrammeCredits { get; set; } = 40;

        // Cost
        [Display(Name = "Programme cost (euro)")]
        [RegularExpression(@"\d{0,5}\.{0,1}\d{0,2}")]
        public decimal ProgrammeCost { get; set; } = 0;

        [ForeignKey("StudentProgrammeID")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
