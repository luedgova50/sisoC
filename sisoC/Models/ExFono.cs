namespace sisoC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class ExFono
    {
        [Key]
        public int ExFonoID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(50, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 5)]
        [Display(Name = "Opción Fonoaudiologico")]
        [Index("ExFono_Description_Index", IsUnique = true)]
        public string Description { get; set; }
    }
}