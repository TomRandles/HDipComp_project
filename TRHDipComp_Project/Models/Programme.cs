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
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        public string ProgrammeID { get; set; }

        // Programme name
        [Required(ErrorMessage = ("Programme name is 6 to 20 characters"))]
        [Display(Name = "Programme name")]
        [MaxLength(20)]
        [RegularExpression(@"[\w\s\.\,\-]{6,20}")]
        public string ProgrammeName { get; set; } = "";

        // Programme description
        [Display(Name = "Programme description")]
        [MaxLength(50)]
        [RegularExpression(@"[\s\w-\,\.\!\@]{0,100}")]
        public string ProgrammeDescription { get; set; } = "";

        // QQI level
        [Display(Name = "Programme QQI level")]
        [RegularExpression(@"\d{1}")]
        public int ProgrammeQQILevel { get; set; } = 5;

        // Credits 
        [Display(Name = "Programme Credits")]
        [RegularExpression(@"\d{1,3}")]
        public int ProgrammeCredits { get; set; } = 40;

        // Cost
        [Display(Name = "Programme cost")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"\d{0,5}\.{0,1}\d{0,2}")]
        public decimal ProgrammeCost { get; set; } = 0;

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }
    }
}
