using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Usuario
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codUsuario { get; set; }

        [ForeignKey("codPersona")]
        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }

        public string configUsuario { get; set; }

        public Usuario(string codUsuario, string codPersona)
        {
            this.codUsuario = codUsuario;
            this.codPersona = codPersona;
            this.configUsuario = "";
        }
    }
}
