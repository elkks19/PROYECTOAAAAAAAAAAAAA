using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Keyless]
    public class Detalle_Wishlist
    {
        [MaxLength(10)]
        [Required]
        public string codWishlist { get; set; }
        [ForeignKey("codWishlist")]
        public Wishlist Wishlist { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        public Producto Producto { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaAnadido { get; set; }

        [DefaultValue(false)]
        public bool isCarrito { get; set; }

        public void Carrito()
        {
            isCarrito = true;
        }
    }
}
