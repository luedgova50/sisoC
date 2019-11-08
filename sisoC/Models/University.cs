namespace sisoC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class University
    {
        [Key]
        public int UniversityID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(150, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 5)]
        [Display(Name = "Universidad")]
        [Index("University_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        public virtual ICollection<TypeLogin> TypeLogins { get; set; }
    }
}