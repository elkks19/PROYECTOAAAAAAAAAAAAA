using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Categoria
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codCategoria { get; set; }

        [MaxLength(50)]
        [Required]
        public string nombreCategoria { get; set; }

        public Categoria(string codCategoria, string nombreCategoria)
        {
            this.codCategoria = codCategoria;
            this.nombreCategoria = nombreCategoria;
        }
    }
}
