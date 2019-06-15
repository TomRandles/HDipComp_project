using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class ProgrammeModule
    {
        // Programme ID - Primary Key 1
        [ForeignKey("Programme")]
        public string ProgrammeID { get; set; }

        // Module ID - Primary Key 2
        [ForeignKey("Module")]
        public string ModuleID { get; set; }

    }
}
