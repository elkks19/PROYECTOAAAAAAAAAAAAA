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

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }

        [Required]
        public string direccionEntregaOrden { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly fechaEntregaOrden { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly fechaPagoOrden { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool isCancelada { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime lastUpdate { get; set; }
        public Orden(string codOrden,
                       string codEmpresa,
                       string codUsuario,
                       string direccion,
                       DateOnly fechaEntrega,
                       DateOnly fechaPago)
        {
            this.codOrden = codOrden;
            this.codEmpresa = codEmpresa;
            this.codUsuario = codUsuario;
            this.direccionEntregaOrden = direccion;
            this.fechaEntregaOrden = fechaEntrega;
            this.fechaPagoOrden = fechaPago;
            this.createdAt = DateTime.Now;
            this.Update();
        }
        public void Cancelar()
        {
            this.isCancelada = true;
        }
        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
