using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
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
        [ForeignKey("codUsuario")]
        public string codUsuario { get; set; }

        [MaxLength(10)]
        [Required]
        [ForeignKey("codProducto")]
        public string codProducto { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaLike { get; set; }

        public Like(string codLike, string codUsuario, string codProducto)
        {
            this.codLike = codLike;
            this.codUsuario = codUsuario;
            this.codProducto = codProducto;
            this.fechaLike = DateTime.Now;
        }
    }
}
