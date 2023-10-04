using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class TokenGuardado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [MaxLength(10)]
        public string codToken { get; set; }

        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }

        [ForeignKey("codPersona")]
        public Persona Persona { get; set; }

        [Required]
        public string Token { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime fechaCreacionToken { get; set; }

        public TokenGuardado()
        {
            this.fechaCreacionToken = DateTime.Now;
        }
    }
}
