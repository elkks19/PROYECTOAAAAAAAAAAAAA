using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class DetalleOrden
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codDetalleOrden { get; set; }

        [MaxLength(10)]
        [Required]
        public string codOrden { get; set; }
        [ForeignKey("codOrden")]
        [Column("codOrden")]
        public Orden Orden { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        [Column("codProducto")]
        public Producto Producto { get; set; }

        public int cantidadProducto { get; set; }
        public float precioTotal { get; set; }
    }
}
