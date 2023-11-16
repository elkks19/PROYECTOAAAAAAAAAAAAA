using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Persona
    {
        public Persona()
        {
            createdAt = DateTime.Now;
            celularPersona = String.Empty;
            Update();
        }

        public void Update()
        {
            lastUpdate = DateTime.Now;
        }


        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codPersona { get; set; }

        [Required]
        [MinLength(8)]
        public string userPersona { get; set; }

        [Required]
        [MinLength(8)]
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

        [MaxLength(70)]
        public string direccionPersona { get; set; }

        [StringLength(8)]
        [Required]
        public string celularPersona { get; set; }

        [Required]
        public string pathFotoPersona { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonIgnore]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonIgnore]
        public DateTime lastUpdate { get; set; }


        // MODELOS RELACIONADOS
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        [JsonIgnore]
        public Administrador Administrador { get; set; }
        [JsonIgnore]
        public PersonalEmpresa PersonalEmpresa { get; set; }
        [JsonIgnore]
        public ICollection<Comentario> Comentarios { get; set; }
        [JsonIgnore]
        public ICollection<LogAuditoria> Logs { get; set; }
        [JsonIgnore]
        public TokenGuardado Token { get; set; }
    }
}
