using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Categoria
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codCategoria { get; set; }

        [MaxLength(30)]
        [Required]
        public string nombreCategoria { get; set; }

        public ICollection<Categorias_Por_Producto> CategoriasProductos { get; set; }

    }
}
