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
        [Required(ErrorMessage = ("Module ID must be 6 alphanumeric characters"))]
        [Display(Name = "Module ID")]
        [MaxLength(6)]
        [RegularExpression(@"\w{6}")]
        public string ModuleID { get; set; }

        // Module name
        [Required(ErrorMessage = ("Module name is at least 6 characters"))]
        [Display(Name = "Module name")]
        [MaxLength(30)]
        [RegularExpression(@"[\w\s\.\,]{6,30}")]
        public string ModuleName { get; set; } = "";

        // Module description
        [Display(Name = "Module description")]
        [MaxLength(50)]
        [RegularExpression(@"[\s\w-\,\.\!]{0,100}")]
        public string ModuleDescription { get; set; } = "";

        // Credits 
        [Display(Name = "Module Credits")]
        [RegularExpression(@"\d{1,3}")]
        public int ModuleCredits { get; set; } = 5;

        public virtual ICollection<Assessment> Assessments { get; set; }

        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }

    }
}
