namespace sisoC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Gender
    {
        [Key]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(20, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 5)]
        [Display(Name = "Genero")]
        [Index("Gender_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        public virtual ICollection<Pacient> Pacients { get; set; }
    }
}