using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ListaEsperaEmpresa
    {
        public bool isAceptado { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaRevision { get; set; }

        public string? razonRevision { get; set; }

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
        public ListaEsperaEmpresa()
        {
            isAceptado= false;
            fechaSolicitudRevision = DateTime.Now;
        }
        public void Denegar()
        {
            isAceptado = false;
            fechaRevision = DateTime.Now;
        }
        public void Aceptar()
        {
            isAceptado = true;
            fechaRevision = DateTime.Now;
        }
    }
}
