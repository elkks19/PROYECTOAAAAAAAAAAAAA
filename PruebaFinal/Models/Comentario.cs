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
        [ForeignKey("codPersona")]
        [Required]
        public string codPersona { get; set; }
        
        [MaxLength(10)]
        [ForeignKey("codProducto")]
        [Required]
        public string codProducto { get; set; }

        public string contenidoComentario { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime createdAt { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime lastUpdate { get; set; }

        public Comentario(string codComentario, string codPersona, string codProducto, string contenidoComentario)
        {
            this.codComentario = codComentario;
            this.codPersona = codPersona;
            this.codProducto = codProducto;
            this.contenidoComentario = contenidoComentario;
            this.createdAt = DateTime.Now;
            this.Update();
        }
        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
