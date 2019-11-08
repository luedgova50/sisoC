namespace sisoC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class TypeLogin
    {
        [Key]
        public int TypeLoginID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Usuario")]
        public int UsersID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Rol Usuario")]
        public int UserRolesID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Contraseña")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", 
            ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Display(Name = "Tarjeta Profesional")]
        public string PrefessionalTarjet { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Universidad")]
        public int UniversityID { get; set; }

        [Display(Name = "Firma")]
        [DataType(DataType.ImageUrl)]
        public string FirmLogin { get; set; }

        [NotMapped]
        public HttpPostedFileBase FirmLoginFile { get; set; }


        public virtual Users Users { get; set; }
        public virtual UserRoles UserRoles { get; set; }
        public virtual University University { get; set; }
    }
}