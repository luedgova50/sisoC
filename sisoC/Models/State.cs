namespace sisoC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class State
    {
        [Key]
        public int StateID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 4)]
        [Display(Name = "Departamento")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(3, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 1)]
        [Display(Name = "Código")]
        public string Code { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}