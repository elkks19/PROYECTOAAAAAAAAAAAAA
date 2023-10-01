﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Reclamos_Empresa
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string codReclamo { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        public Producto Producto { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        public Usuario? Usuario { get; set; }

        [Required]
        public string contenidoReclamo { get; set; }
        public string? respuestaReclamo { get; set; }

        [MaxLength(10)]
        [Required]
        public string codAdmin { get; set; }
        [ForeignKey("codAdmin")]
        public Administrador Administrador { get; set; }

        [DefaultValue(false)]
        public bool isRevisado { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaCreacionReclamo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaRevisionReclamo { get; set; }

    }
}
