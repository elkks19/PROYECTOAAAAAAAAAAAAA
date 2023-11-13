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

        public ICollection<Like> Likes { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<ReclamosEmpresa> Reclamos { get; set; }
        public ICollection<VisitasEmpresa> VisitasEmpresa { get; set; }
        public ICollection<GuardadoWishlist> GuardadoWishlist { get; set; }
        public ICollection<GuardadoCarrito> GuardadoCarrito { get; set; }

    }
}
