using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    [Keyless]
    public class Detalle_Orden
    {
        [MaxLength(10)]
        [ForeignKey("codOrden")]
        [Required]
        public string codOrden { get; set; }

        [MaxLength(10)]
        [ForeignKey("codProducto")]
        [Required]
        public string codProducto { get; set; }

        public int cantidadProducto { get; set; }
        public float precioTotal { get; set; }
        public Detalle_Orden(string codOrden, string codProducto, int cantidad, float total)
        {
            this.codOrden = codOrden;
            this.codProducto = codProducto;
            this.cantidadProducto = cantidad;
            this.precioTotal = total;
        }
    }
}
