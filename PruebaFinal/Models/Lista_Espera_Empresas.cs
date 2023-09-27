using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    [Keyless]
    public class Lista_Espera_Empresas
    {
        [DefaultValue(false)]
        public bool isRevisado { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaRevisado { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaSolicitudRevision { get; set; }

        [MaxLength(10)]
        [Required]
        [ForeignKey("codEmpresa")]
        public string codEmpresa { get; set; }

        [MaxLength(10)]
        [Required]
        [ForeignKey("codAdmin")]
        public string codAdmin { get; set; }

        public Lista_Espera_Empresas(string codAdmin, string codEmpresa)
        {
            this.fechaSolicitudRevision = DateTime.Now;
            this.codAdmin = codAdmin;
            this.codEmpresa = codEmpresa;
        }
        public void Revisado()
        {
            this.isRevisado = true;
            this.fechaRevisado = DateTime.Now;
        }
    }
}
