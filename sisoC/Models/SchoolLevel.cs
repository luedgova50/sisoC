namespace sisoC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SchoolLevel
    {
        [Key]
        public int SchoolLevelID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 5)]
        [Display(Name = "Nivel Escolar")]
        [Index("SchoolLevel_Description_Index", IsUnique = true)]
        public string Description { get; set; }
    }
}