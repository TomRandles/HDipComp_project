using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class Programme
    {
        // Programme ID - Primary Key
        [Key]
        [Required(ErrorMessage = "Programme ID required")] 
        [Display(Name = "Programme ID")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}")]
        [ConcurrencyCheck]
        public string ProgrammeID { get; set; }

        // Programme name
        [Required(ErrorMessage = "Programme name required")]
        [Display(Name = "Programme name")]
        [StringLength(20, ErrorMessage = "6 to 20 characters")]
        [RegularExpression(@"[\w\s\.\-]{6,20}")]

        public string ProgrammeName { get; set; } = "";

        // Programme description
        [Display(Name = "Programme description")]
        [StringLength(100, ErrorMessage = "100 characters max")]
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
        [Required(ErrorMessage = "Programme fee required")]
        [Display(Name = "Programme cost")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"\d{0,5}\.{0,1}\d{0,2}")]
        public decimal ProgrammeCost { get; set; } = 0;

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }
    }
}
