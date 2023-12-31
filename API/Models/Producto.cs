﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
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
        [JsonIgnore]
        public Empresa Empresa { get; set; }

        [MaxLength(50)]
        [Required]
        public string nombreProducto { get; set; }

        [Required]
        public string descProducto { get; set; }
        [Required]
        public float precioProducto { get; set; }
        [Required]
        public float precioEnvioProducto { get; set; }

        [Required]
        public string pathFotoProducto { get; set; }

        [Required]
        public int cantidadRestante { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime createdAt { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime lastUpdate { get; set; }

        [Required]
        public bool activo { get; set; }

        // RELACIONES
        [JsonIgnore]
        public ICollection<ReclamosEmpresa> Reclamos { get; set; }
        [JsonIgnore]
        public ICollection<Like> Likes { get; set; }
        [JsonIgnore]
        public ICollection<CategoriasPorProducto> CategoriasProductos { get; set; }
        [JsonIgnore]
        public ICollection<DetalleOrden> Ordenes { get; set; }
        [JsonIgnore]
        public ICollection<Wishlist> Wishlists { get; set; }

        public Producto()
        {
            activo = true;
            createdAt = DateTime.Now;
            lastUpdate = DateTime.Now;
        }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
        public void Desactivar()
        {
            activo = false;
        }
    }
}
