using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Persona
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codPersona { get; set; }

        [MaxLength(20)]
        [Required]
        public string nombrePersona { get; set; }

        [MaxLength(20)]
        [Required]
        public string apPaternoPersona { get; set; }

        [MaxLength(20)]
        [Required]
        public string apMaternoPersona { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaNacPersona { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string mailPersona { get; set; }

        [MaxLength(10)]
        [Required]
        public string ciPersona { get; set; }

        [MaxLength(50)]
        public string direccionPersona { get; set; }

        [MaxLength(50)]
        [Required]
        public string userPersona { get; set; }

        [MaxLength(50)]
        [Required]
        public string passwordPersona { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime lastUpdate { get; set; }
        
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Administrador> Administradores{ get; set; }
        public ICollection<Personal_Empresa> Personal_Empresas { get; set; }
        public ICollection<Comentario> Comentarios { get; set; }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
