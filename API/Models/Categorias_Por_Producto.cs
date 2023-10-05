using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Categorias_Por_Producto
    {
        [MaxLength(10)]
        [Required]
        public string codCategoria { get; set; }
        [ForeignKey("codCategoria")]
        [Column("codCategoria")]
        public Categoria Categoria { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        [Column("codProducto")]
        public Producto Producto { get; set; }

    }
}