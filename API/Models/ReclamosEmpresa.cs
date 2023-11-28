using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class ReclamosEmpresa
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string codReclamo { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        [JsonIgnore]
        public Producto Producto { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [Required]
        public string contenidoReclamo { get; set; }


        [MaxLength(10)]
        [Required]
        public string codAdmin { get; set; }
        [ForeignKey("codAdmin")]
        [JsonIgnore]
        public Administrador Administrador { get; set; }

        public bool isRevisado { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaCreacionReclamo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaRevisionReclamo { get; set; }
        public string? respuestaReclamo { get; set; }

        [Required]
        public bool activo { get; set; }

        public ReclamosEmpresa()
        {
            activo = true;
            isRevisado = false;
            fechaCreacionReclamo = DateTime.Now;
        }
        public void Responder(string respuesta)
        {
            respuestaReclamo = respuesta;
            fechaRevisionReclamo = DateTime.Now;
        }
        public void Desactivar()
        {
            activo = false;
        }
    }
}
