using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Administrador
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codAdmin { get; set; }
        public virtual ICollection<Administrador> Administradores { get; set; } = new List<Administrador>();

        [MaxLength(10)]
        [ForeignKey("codPersona")]
        [Required]
        public string codPersona { get; set; }
        public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
        public Administrador(string codAdmin, string codPersona)
        {
            this.codAdmin = codAdmin;
            this.codPersona = codPersona;
        }
    }
}
