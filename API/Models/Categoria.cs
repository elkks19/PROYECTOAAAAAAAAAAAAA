﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
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

        [Required]
        public bool activo { get; set; }

        public ICollection<CategoriasPorProducto> CategoriasProductos { get; set; }

        public Categoria()
        {
            Activar();
        }
        public void Desactivar()
        {
            activo = false;
        }
        public void Activar()
        {
            activo = true;
        }
    }
}
