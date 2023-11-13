using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Administrador
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codAdmin { get; set; }

        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }
        [ForeignKey("codPersona")]
        public Persona Persona { get; set; }
        public ICollection<ListaEsperaEmpresa> ListaEsperaEmpresas { get; set; }
        public ICollection<ReclamosEmpresa> Reclamos { get; set; }
    }
}
