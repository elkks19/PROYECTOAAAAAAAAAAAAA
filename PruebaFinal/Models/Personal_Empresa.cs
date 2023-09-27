using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Personal_Empresa
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codPersonalEmpresa { get; set; }

        [MaxLength(10)]
        [ForeignKey("codEmpresa")]
        [Required]
        public string codEmpresa { get; set; }

        [MaxLength(10)]
        [ForeignKey("codPersona")]
        [Required]
        public string codPersona { get; set; }

        public Personal_Empresa(string codPersonalEmpresa, string codEmpresa, string codPersona)
        {
            this.codPersonalEmpresa = codPersonalEmpresa;
            this.codEmpresa = codEmpresa;
            this.codPersona = codPersona;
        }
    }
}
