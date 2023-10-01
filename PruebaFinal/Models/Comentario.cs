using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Comentario
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codComentario { get; set; }

        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }
        [ForeignKey("codPersona")]
        public Persona Persona { get; set; }
        
        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        public Producto Producto { get; set; }

        public string contenidoComentario { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime createdAt { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime lastUpdate { get; set; }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
