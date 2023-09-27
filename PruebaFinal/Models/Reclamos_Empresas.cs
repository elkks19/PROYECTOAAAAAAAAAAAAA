using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Reclamos_Empresas
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string codReclamo { get; set; }

        [MaxLength(10)]
        [Required]
        [ForeignKey("codProducto")]
        public string codProducto { get; set; }

        [Required]
        public string contenidoReclamo { get; set; }
        public string? respuestaReclamo { get; set; }

        [MaxLength(10)]
        [Required]
        [ForeignKey("codAdmin")]
        public string codAdmin { get; set; }

        [DefaultValue(false)]
        public bool isRevisado { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaCreacionReclamo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaRevisado { get; set; }

        public Reclamos_Empresas(string codReclamo, string codProducto, string contenidoReclamo, string codAdmin)
        {
            this.codReclamo = codReclamo;
            this.codProducto = codProducto;
            this.contenidoReclamo = contenidoReclamo;
            this.codAdmin = codAdmin;
            this.fechaCreacionReclamo = DateTime.Now;
        }
        public void Revisado(string respuestaReclamo)
        {
            this.respuestaReclamo = respuestaReclamo;
            this.isRevisado = true;
            this.fechaRevisado = DateTime.Now;
        }
    }
}
