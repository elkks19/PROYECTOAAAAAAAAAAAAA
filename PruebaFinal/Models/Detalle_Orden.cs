using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    [Keyless]
    public class Detalle_Orden
    {
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
