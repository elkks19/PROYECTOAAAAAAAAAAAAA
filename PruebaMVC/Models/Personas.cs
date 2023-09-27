using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMVC.Models
{
    public class Personas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(10)]
        public string codPersona { get; set; }
        public string nombrePersona { get; set; }
        public string apPaternoPersona { get; set; }
        public string apMaternoPersona { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaNacPewsona { get; set; }
        public string mailPersona { get; set; }
        public string? ciPersona { get; set; }
        public string? direccionPersona { get; set; }
        public string userPersona { get; set; }
        public string passwordPersona { get; set; }
        [DefaultValue(false)]
        public bool isActivo { get; set; }
    }
}
