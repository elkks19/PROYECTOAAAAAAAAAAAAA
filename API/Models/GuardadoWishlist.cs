using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class GuardadoWishlist
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codGuardadoWishlist { get; set; }

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

        public GuardadoWishlist()
        {
            fechaGuardado = DateTime.Now;
        }
    }
}
