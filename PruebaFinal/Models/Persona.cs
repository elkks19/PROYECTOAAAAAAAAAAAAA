using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinal.Models
{
    public class Persona
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codPersona { get; set; }

        [MaxLength(20)]
        [Required]
        public string nombrePersona { get; set; }

        [MaxLength(20)]
        [Required]
        public string apPaternoPersona { get; set; }

        [MaxLength(20)]
        [Required]
        public string apMaternoPersona { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime fechaNacPersona { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string mailPersona { get; set; }

        [MaxLength(10)]
        [Required]
        public string ciPersona { get; set; }

        [MaxLength(50)]
        public string direccionPersona { get; set; }

        [MaxLength(60)]
        [Required]
        public string userPersona { get; set; }

        [MaxLength(60)]
        [Required]
        public string passwordPersona { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime createdAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime lastUpdate { get; set; }
        public Persona(string codPersona,
                        string nombre,
                        string apPaterno,
                        string apMaterno,
                        DateTime fechaNac,
                        string mail,
                        string ci,
                        string direccion,
                        string user,
                        string password)
        {
            this.codPersona = codPersona;
            this.nombrePersona = nombre;
            this.apPaternoPersona = apPaterno;
            this.apMaternoPersona = apMaterno;
            this.fechaNacPersona = fechaNac;
            this.mailPersona = mail;
            this.ciPersona = ci;
            this.direccionPersona = direccion;
            this.userPersona = user;
            this.passwordPersona = password;
            this.createdAt = DateTime.Now;
            this.Update();
        }
        public void Update()
        {
            lastUpdate = DateTime.Now;
        }
    }
}
