﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMVC.Models
{
    public class Usuarios
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codUsuario{ get; set; }
        public string configuracionUsuario { get; set; }
        [MaxLength(10)]
        public string codPersona { get; set; }
        [ForeignKey("codPersona")]
        public virtual Personas Persona { get; set; }
    }
}
