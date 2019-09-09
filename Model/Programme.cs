using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRHDipComp_Project.Models
{
    public class Programme
    {
        #region properties
        // Programme ID - Primary Key
        [Key]
        [Required(ErrorMessage = "Programme ID required")] 
        [Display(Name = "Programme ID")]
        [StringLength(6, ErrorMessage = "Must be 6 alphanumeric characters")]
        [RegularExpression(@"\w{6}", ErrorMessage = "Must be 6 alphanumeric characters")]
        [ConcurrencyCheck]
        public string ProgrammeID { get; set; }

        // Programme name
        [Required(ErrorMessage = "Programme name required")]
        [Display(Name = "Programme name")]
        [StringLength(30, ErrorMessage="Cannot exceed 30 characters.")]
        [RegularExpression(@"[\w\s\.\-]{6,30}", ErrorMessage = "Name is 6 to 30 characters. Space, periods, hyphens allowed.")]

        public string ProgrammeName { get; set; } = "";

        // Programme description - optional
        [Display(Name = "Programme description")]
        [StringLength(200, ErrorMessage = "200 characters max")]
        public string ProgrammeDescription { get; set; } = "";

        // QQI level
        [Display(Name = "Programme QQI level")]
        [RegularExpression(@"[0-9]{1,2}", ErrorMessage = "Must be a whole number, one to two digits ")]
        [Range(1,10, ErrorMessage = "QQI level must be between 1 and 10.")]
        public int ProgrammeQQILevel { get; set; } = 5;

        // Credits 
        [Display(Name = "Programme Credits")]
        [Range(5, 300, ErrorMessage ="Credits must be between 5 and 300")]
        [RegularExpression(@"\d{1,3}", ErrorMessage = "Must be a numeric value, 1 to 3 digits ")]
        public int ProgrammeCredits { get; set; } = 40;

        // Cost
        [Required(ErrorMessage = "Programme fee required")]
        [Display(Name = "Programme cost")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression(@"\d{0,5}\.{0,1}\d{0,2}", ErrorMessage = "Incorrect entry. Must be a monetary value between 0.00 and 99999.99. Only 2 decimal places.")]
        public decimal ProgrammeCost { get; set; } = 0;

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<ProgrammeModule> ProgrammeModules { get; set; }
        #endregion
    }
}
