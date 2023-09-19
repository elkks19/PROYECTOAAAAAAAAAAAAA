using System.ComponentModel.DataAnnotations;

namespace PruebaMVC.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Apellidos { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

    }
}
