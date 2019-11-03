namespace sisoC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class DriveLicense
    {
        [Key]
        public int DriveLicenseID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(3, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 1)]
        [Display(Name = "Categoria Licencia")]
        [Index("DriveLicense_Description_Index", IsUnique = true)]
        public string Description { get; set; }
    }
}