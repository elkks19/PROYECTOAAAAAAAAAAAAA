using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Orden
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codOrden { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public string direccionEntregaOrden { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? fechaEntregaOrden { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? fechaPagoOrden { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool isCancelada { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime lastUpdate { get; set; }

        [JsonIgnore]
        public ICollection<DetalleOrden> Ordenes { get; set; }

        public Orden()
        {
            createdAt = DateTime.Now;
            Update();
        }
        public void Cancelar()
        {
            isCancelada = true;
        }
        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
