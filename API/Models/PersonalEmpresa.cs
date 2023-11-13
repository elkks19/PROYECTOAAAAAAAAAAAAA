using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class PersonalEmpresa
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codPersonalEmpresa { get; set; }

        [MaxLength(10)]
        [Required]
        public string codEmpresa { get; set; }
        [ForeignKey("codEmpresa")]
        public Empresa Empresa { get; set; }

        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }
        [ForeignKey("codPersona")]
        public Persona Persona { get; set; }

    }
}
