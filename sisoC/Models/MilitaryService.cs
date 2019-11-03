namespace sisoC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MilitaryService
    {
        [Key]
        public int MilitaryServiceID { get; set; }

        [StringLength(2,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 1)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Servicio Militar")]
        public string Options { get; set; }

        public virtual ICollection<Pacient> Pacients { get; set; }
    }
}