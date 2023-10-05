using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Like
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codLike { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        public Usuario Usuario { get; set; }

        [MaxLength(10)]
        [Required]
        public string codProducto { get; set; }
        [ForeignKey("codProducto")]
        public Producto Producto { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaLike { get; set; }

    }
}
