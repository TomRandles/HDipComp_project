using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRHDipComp_Project.Models
{
    public class Module
    {
        // Module ID - Primary Key
        [Key]
        [Display(Name = "Module ID")]
        [StringLength(6, ErrorMessage = ("Must be 6 characters"))]
        [RegularExpression(@"\w{6}")]
        public string ModuleID { get; set; }

        // Module name
        [Required]
        [Display(Name = "Module name")]
        [StringLength(30, ErrorMessage = ("Maximum 30 characters"))]
        [RegularExpression(@"[\w\s\.\,\-]{6,30}")]
        [ConcurrencyCheck]
        public string ModuleName { get; set; } = "";

        // Module description
        [Display(Name = "Module description")]
        [StringLength(50, ErrorMessage = ("Maximum 50 characters"))]
        public string ModuleDescription { get; set; } = "";

        // Credits 
        [Display(Name = "Module Credits")]
        [RegularExpression(@"\d{1,3}")]
        public int ModuleCredits { get; set; } = 5;

        public virtual ICollection<Assessment> Assessments { get; set; }

        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }

    }
}
