namespace sisoC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Examen
    {
        [Key]
        public int ExamenID { get; set; }        
        
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Appointment Time is required")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Hora")]
        public TimeSpan? Time { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Tipo")]
        public int ExamenTypeID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Nivel")]
        public int ExamenLevelID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Otro")]
        public int OtherExamID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Paciente")]
        public int PacientID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Empresa")]
        public int EnterpriseID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Optometria")]
        public int ExOptoID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Fonoaudiología")]
        public int ExFonoID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Psicosensometrico")]
        public int ExPsicoID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Médico")]
        public int ExMedicoID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Activo")]
        public int ExActivoID { get; set; }

        public virtual ExamenType ExamenType { get; set; }
        public virtual ExamenLevel ExamenLevel { get; set; }
        public virtual OtherExam OtherExam { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual ExOpto ExOpto { get; set; }
        public virtual ExFono ExFono { get; set; }
        public virtual ExPsico ExPsico { get; set; }
        public virtual ExMedico ExMedico { get; set; }
        public virtual ExActivo ExActivo { get; set; }
    }
}