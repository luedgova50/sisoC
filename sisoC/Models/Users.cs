namespace sisoC.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class Users
    {
        [Key]
        public int UsersID { get; set; }

        [StringLength(256,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 10)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "User Name")]
        [Index("Users_UserName_Index", 2, IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Tipo Documento")]
        public int DocumentTypeID { get; set; }

        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 5)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Index("Users_Document_Index", 1, IsUnique = true)]
        [Display(Name = "Número Documento")]
        public string Document { get; set; }

        [StringLength(30,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Nombre(s)")]
        public string FirstName { get; set; }

        [StringLength(30,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Apellido(s)")]
        public string LastName { get; set; }

        [StringLength(100,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Departamento")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Ciudad")]
        public int CityID { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Display(Name = "Móvil Uno")]
        public string Movil1 { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Display(Name = "Movil Dos")]
        public string Movil2 { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage = "E-mail is not valid")]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        public string PhotoUsers { get; set; }

        [Display(Name = "Firma")]
        [DataType(DataType.ImageUrl)]
        public string FirmUsers { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoUsersFile { get; set; }

        [NotMapped]
        public HttpPostedFileBase FirmUsersFile { get; set; }

        [NotMapped]
        [Display(Name = "Nombres")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}",
              FirstName, LastName);
            }
        }

        public virtual DocumentType DocumentType { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
    }
}