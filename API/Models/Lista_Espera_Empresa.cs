using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
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
        public Lista_Espera_Empresa()
        {
            isRevisado = false;
            fechaSolicitudRevision = DateTime.Now;
        }
        public void Revisado()
        {
            isRevisado = true;
            fechaRevision = DateTime.Now;
        }
    }
}
