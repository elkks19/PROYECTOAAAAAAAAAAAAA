using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Wishlist
    {
        [ForeignKey("codWishlist")]
        [MaxLength(10)]
        [Required]
        public string codWishlist { get; set; }

        [ForeignKey("codUsuario")]
        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        public Wishlist(string codWishlist, string codUsuario)
        {
            this.codWishlist = codWishlist;
            this.codUsuario = codUsuario;
        }
    }
}
