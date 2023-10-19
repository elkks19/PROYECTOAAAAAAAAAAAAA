using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace API.Models
{
    public class Empresa
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codEmpresa { get; set; }

        [MaxLength(50)]
        [Required]
        public string nombreEmpresa { get; set; }

        [MaxLength(50)]
        [Required]
        public string direccionEmpresa { get; set; }

        [Required]
        public string archivoVerificacionEmpresa { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime createdAt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime lastUpdate { get; set; }
        public ICollection<Personal_Empresa> Personal { get; set; }
        public ICollection<Producto> Productos { get; set; }

        public Empresa()
        {
            createdAt = DateTime.Now;
            Update();
        }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
