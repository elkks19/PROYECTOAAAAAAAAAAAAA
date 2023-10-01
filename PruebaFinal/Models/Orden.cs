using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
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
        public string codEmpresa { get; set; }
        [ForeignKey("codEmpresa")]
        public Empresa Empresa { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public string direccionEntregaOrden { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaEntregaOrden { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaPagoOrden { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool isCancelada { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime lastUpdate { get; set; }
        
        public void Cancelar()
        {
            this.isCancelada = true;
        }
        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
        public ICollection<Producto> Productos { get; set; }
    }
}
