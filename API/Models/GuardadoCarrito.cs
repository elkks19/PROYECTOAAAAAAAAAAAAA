using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class GuardadoCarrito
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codGuardadoCarrito { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        [JsonIgnore]
        public Producto Producto { get; set; }


        [DataType(DataType.Date)]
        public DateTime fechaGuardado { get; set; }

        public GuardadoCarrito()
        {
            fechaGuardado = DateTime.Now;
        }
    }
}
