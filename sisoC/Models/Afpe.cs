namespace sisoC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Afpe
    {
        [Key]
        public int AfpeID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(50, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 5)]
        [Display(Name = "AFP")]
        [Index("Afpe_Description_Index", IsUnique = true)]
        public string Description { get; set; }
    }
}