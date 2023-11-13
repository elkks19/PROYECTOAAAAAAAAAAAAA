using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class LogAuditoria
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codLog { get; set; }

        [MaxLength(10)]
        [Required]
        public string codPersona { get; set; }
        [ForeignKey("codPersona")]
        public virtual Persona Persona { get; set; }

        public string accionLog { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [JsonIgnore]
        public DateTime fechaLog { get; set; }


        public LogAuditoria()
        {
            fechaLog = DateTime.Now;
        }
    }
}
