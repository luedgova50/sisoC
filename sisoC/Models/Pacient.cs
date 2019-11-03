namespace sisoC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class Pacient
    {
        [Key]
        public int PacientID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Tipo Documento")]
        public int DocumentTypeID { get; set; }

        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 5)]
        [Required(ErrorMessage = "You must enter the field {0}")]
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

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Genero")]
        public int GenderID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You must enter a {0}")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime BirthDay { get; set; }

        [StringLength(50,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Lugar Nacimiento")]
        public string BirthPlace { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Estado Civil")]
        public int CivilID { get; set; }

        [StringLength(50,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Entorno Familiar")]
        public string Family { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Factor RH")]
        public int FactorRhID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Nivel Escolar")]
        public int SchoolLevelID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Profesión")]
        public int ProfessionID { get; set; }

        [StringLength(5,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 1)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Tiempo Profesión")]
        public string TimeProfession { get; set; }

        [StringLength(50,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 1)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Cargo")]
        public string Possition { get; set; }

        [StringLength(3,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 1)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Antiguedad Meses")]
        public string OldMount { get; set; }

        [StringLength(2,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 1)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Antiguedad Años")]
        public string OldYear { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Servicio Militar")]
        public int MilitaryServiceID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Categoria Licencia")]
        public int DriveLicenseID { get; set; }

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

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "EPS")]
        public int EpsaID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "ARP")]
        public int ArprID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "AFP")]
        public int AfpeID { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Firm { get; set; }

        [NotMapped]
        [Display(Name = "Foto")]
        public HttpPostedFileBase PhotoFile { get; set; }

        [NotMapped]
        [Display(Name = "Firma")]
        public HttpPostedFileBase FirmFile { get; set; }

        [NotMapped]
        [Display(Name = "Nombres")]
        public string FullName { 
            get { return string.Format("{0} {1}", 
                FirstName, LastName); } }

        public virtual DocumentType DocumentType { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Civil Civil { get; set; }
        public virtual FactorRh FactorRh { get; set; }
        public virtual SchoolLevel SchoolLevel { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual MilitaryService Military { get; set; }
        public virtual DriveLicense DriveLicense { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual Epsa Epsa { get; set; }
        public virtual Arpr Arpr { get; set; }
        public virtual Afpe Afpe { get; set; }

    }
}