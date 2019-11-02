namespace sisoC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 4)]
        [Display(Name = "Ciudad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(3, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 1)]
        [Display(Name = "Código")]
        [Index("City_Code_Index", IsUnique = true)]
        public string Code { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Departamento")]
        public int StateID { get; set; }

        public virtual State State { get; set; }


    }
}