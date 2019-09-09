using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TRHDipComp_Project.Models
{
    // A module is a soecific are of study, such as maths, relational databases etc.
    public class Module
    {
        #region properties
        // Module ID - Primary Key
        [Key]
        [Required(ErrorMessage = "Module ID is required")]
        [Display(Name = "Module ID")]
        [StringLength(6, ErrorMessage = "Must be 6 characters")]
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 characters")]
        [ConcurrencyCheck]
        public string ModuleID { get; set; }

        // Module name
        [Required]
        [Display(Name = "Module name")]
        [RegularExpression(@"[\w\s\.\,\-]{3,30}", ErrorMessage = "Requires between 3 and 30 characters. Space, periods, hyphens allowed.")]
        public string ModuleName { get; set; } = "";

        // Module description
        [Display(Name = "Module description")]
        [StringLength(200, ErrorMessage = ("Maximum 200 characters"))]
        public string ModuleDescription { get; set; } = "";

        // Credits 
        [Display(Name = "Module Credits")]
        [Range(5, 20, ErrorMessage = "Credits must be between 5 and 20")]
        [RegularExpression(@"\d{1,2}", ErrorMessage = "Must be a numeric value, 1 to 2 digits ")]
        public int ModuleCredits { get; set; } = 5;

        public virtual ICollection<Assessment> Assessments { get; set; }

        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }
        #endregion
    }
}
