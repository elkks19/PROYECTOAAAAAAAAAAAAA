using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public DateTime createdAt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [JsonIgnore]
        public DateTime lastUpdate { get; set; }
        [JsonIgnore]
        public ICollection<Personal_Empresa> Personal { get; set; }
        [JsonIgnore]
        public ICollection<Producto> Productos { get; set; }
        [JsonIgnore]
        public Lista_Espera_Empresa ListaEspera { get; set; }

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
