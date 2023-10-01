using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    [Keyless]
    public class Lista_Espera_Empresa
    {
        [DefaultValue(false)]
        public bool isRevisado { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaRevision { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaSolicitudRevision { get; set; }

        [MaxLength(10)]
        [Required]
        public string codEmpresa { get; set; }
        [ForeignKey("codEmpresa")]
        public Empresa Empresa { get; set; }

        [MaxLength(10)]
        [Required]
        public string codAdmin { get; set; }
        [ForeignKey("codAdmin")]
        public Administrador Administrador { get; set; }

        public void Revisado()
        {
            this.isRevisado = true;
            this.fechaRevision = DateTime.Now;
        }
    }
}
