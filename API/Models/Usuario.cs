using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Usuario
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codUsuario { get; set; }

        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }
        [ForeignKey("codPersona")]
        public Persona Persona { get; set; }

        public string configUsuario { get; set; } = string.Empty;

        public ICollection<Like> Likes { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Reclamos_Empresa> Reclamos { get; set; }
    }
}
