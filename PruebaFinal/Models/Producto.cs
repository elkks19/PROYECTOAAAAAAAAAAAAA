using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Producto
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codProducto { get; set; }

        [MaxLength(10)]
        [Required]
        public string codEmpresa { get; set; }
        [ForeignKey("codEmpresa")]
        public Empresa Empresa { get; set; }

        [MaxLength(50)]
        [Required]
        public string nombreProducto { get; set; }

        [MaxLength(100)]
        [Required]
        public string descProducto { get; set; }
        [Required]
        public float precioProducto { get; set; }
        [Required]
        public float envioProducto { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        public string pathFotoProducto { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime createdAt { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime lastUpdate { get; set; }

        // RELACIONES
        public ICollection<Reclamos_Empresa> Reclamos { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Categorias_Por_Producto> CategoriasProductos { get; set; }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
