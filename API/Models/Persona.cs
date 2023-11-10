using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Persona
    {

        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codPersona { get; set; }

        [Required]
        public string userPersona { get; set; }

        [Required]
        public string passwordPersona { get; set; }

        [MaxLength(70)]
        [Required]
        public string nombrePersona { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaNacPersona { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string mailPersona { get; set; }

        [MaxLength(50)]
        public string direccionPersona { get; set; }

        [StringLength(8)]
        [Required]
        public string celularPersona { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        [JsonIgnore]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonIgnore]
        public DateTime lastUpdate { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
        [JsonIgnore]
        public Administrador Administrador { get; set; }
        [JsonIgnore]
        public Personal_Empresa Personal_Empresa { get; set; }
        [JsonIgnore]
        public ICollection<Comentario> Comentarios { get; set; }
        [JsonIgnore]
        public ICollection<Log_Auditoria> Logs { get; set; }

        [JsonIgnore]
        public TokenGuardado Token { get; set; }
        public Persona()
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
