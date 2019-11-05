namespace sisoC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserRoles
    {
        [Key]
        public int UserRolesID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(50, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 3)]
        [Display(Name = "Rol Usuario")]
        [Index("UserRoles_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        //public virtual ICollection<Pacient> Pacients { get; set; }
    }
}