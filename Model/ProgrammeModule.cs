using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{

    // This class is the junction entity to manage the many-to-many relationship between Programmes and
    // Modules

    public class ProgrammeModule
    {
        #region properties
        // The Complex primary key ProgrammeID-ModuleID is setup in CollegeDbContext 

        // Programme ID - Primary Key 1

        [ForeignKey("Programme")]
        [Required (ErrorMessage="Programme ID is required.")]
        [ConcurrencyCheck]
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 alphanumeric characters")]
        public string ProgrammeID { get; set; }

        // Module ID - Primary Key 2
        [ForeignKey("Module")]
        [Required(ErrorMessage = "Module ID is required.")]
        [ConcurrencyCheck] 
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 alphanumeric characters")]
        public string ModuleID { get; set; }

        public virtual ICollection<AssessmentResult> AssessmentResults { get; set; }
        #endregion

        // Teacher teaching this particular module on this programme  - Foreign Key        
        [Display(Name = "Teacher ID:")]
        [StringLength(7, ErrorMessage = "Must be 7 characters")]
        [RegularExpression(@"[tT]{1}[0-9]{6}", ErrorMessage = "Must be a single \'T\' character followed by 6 digits")]
        [ForeignKey("Teacher")]
        public string TeacherID { get; set; } = "";

    }
}