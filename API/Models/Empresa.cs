using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
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

        [Required]
        public string direccionEmpresa { get; set; }

        [Required]
        public string archivoVerificacionEmpresa { get; set; }

        [Required]
        public string socialMediaEmprsa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime createdAt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime lastUpdate { get; set; }


        [JsonIgnore]
        public ICollection<PersonalEmpresa> Personal { get; set; }
        [JsonIgnore]
        public ICollection<Producto> Productos { get; set; }
        [JsonIgnore]
        public ListaEsperaEmpresa ListaEspera { get; set; }
        [JsonIgnore]
        public ICollection<VisitasEmpresa> Visitas { get; set; }

        [Required]
        public bool activo { get; set; }

        public Empresa()
        {
            activo = true;
            var json = new
            {
                instagram = String.Empty,
                facebook = String.Empty,
                twitter = String.Empty
            };
            socialMediaEmprsa = JsonSerializer.Serialize(json);

            createdAt = DateTime.Now;
            Update();
        }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }

        public void Desactivar()
        {
            activo = false;
        }
    }
}
