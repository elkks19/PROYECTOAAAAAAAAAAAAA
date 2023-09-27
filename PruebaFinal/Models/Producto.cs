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
        public virtual ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        public Producto(string codProducto,
                         string codEmpresa,
                         string nombre,
                         string descripcion,
                         float precio,
                         float costoEnvio,
                         string pathFoto)
        {
            this.codProducto = codProducto;
            this.codEmpresa = codEmpresa;
            this.nombreProducto = nombre;
            this.descProducto = descripcion;
            this.precioProducto = precio;
            this.envioProducto = costoEnvio;
            this.pathFotoProducto = pathFoto;
            this.createdAt = DateTime.Now;
            this.Update();
        }
        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
