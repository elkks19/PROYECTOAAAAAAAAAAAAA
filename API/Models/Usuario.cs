using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
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
        public virtual Persona Persona { get; set; }

        public string configUsuario { get; set; } = string.Empty;

        [Required]
        public string pathFotoUsuario { get; set; } = "C:\\Users\\rafaf\\Desktop\\PROYECTO\\ProyectoEquisDe\\API\\Imagenes\\perrito.jpg";

        public ICollection<Like> Likes { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Reclamos_Empresa> Reclamos { get; set; }
    }
}
