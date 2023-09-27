using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    [Keyless]
    public class Categorias_Por_Producto
    {
        [ForeignKey("codCategoria")]
        [MaxLength(10)]
        [Required]
        public string codCategoria { get; set; }
        public virtual Categoria categoria { get; set; } = null!;

        [ForeignKey("codCategoria")]
        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        public virtual Producto producto { get; set; } = null!;

        public Categorias_Por_Producto(string codCategoria, string codProducto)
        {
            this.codCategoria = codCategoria;
            this.codProducto = codProducto;
        }
    }
}
