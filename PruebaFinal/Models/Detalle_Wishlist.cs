using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    [Keyless]
    public class Detalle_Wishlist
    {
        [ForeignKey("codWishlist")]
        [MaxLength(10)]
        [Required]
        public string codWishlist { get; set; }

        [ForeignKey("codProducto")]
        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaAnadido { get; set; }

        [DefaultValue(false)]
        public bool isCarrito { get; set; }

        public Detalle_Wishlist(string codWishlist, string codProducto)
        {
            this.codWishlist = codWishlist;
            this.codProducto = codProducto;
            this.fechaAnadido = DateTime.Now;
        }
        public void Carrito()
        {
            this.isCarrito = true;
        }
    }
}
