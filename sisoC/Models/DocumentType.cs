namespace sisoC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(3, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 1)]
        [Display(Name = "Tipo Documento")]
        [Index("DocumentType_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        public virtual ICollection<Pacient> Pacients { get; set; }
    }
}