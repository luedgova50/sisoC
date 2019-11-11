namespace sisoC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Enterprise
    {
        [Key]
        public int EnterpriseID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Tipo")]
        public int DocumentTypeID { get; set; }

        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 5)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Index("Enterprise_Document_Index", IsUnique = true)]
        [Display(Name = "Número")]
        public string Document { get; set; }

        [StringLength(150,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Razón Social")]
        public string BusinessName { get; set; }

        [StringLength(150,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Nombre Contacto")]
        public string ContactName { get; set; }

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
        
        [DataType(DataType.Url)]
        [Display(Name = "Web Site")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$",
            ErrorMessage = "URL is not valid")]
        public string URL { get; set; }

        [StringLength(20,
            ErrorMessage = "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Display(Name = "Forma Pago")]
        [Required(ErrorMessage = "You must enter a {0}")]
        public string TypePay { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Examen> Examens { get; set; }
    }
}