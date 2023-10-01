using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
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
        public ICollection<Lista_Espera_Empresa> Lista_Espera_Empresas { get; set; }
        public ICollection<Reclamos_Empresa> Reclamos { get; set; }
    }
}
