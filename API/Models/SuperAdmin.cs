using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace API.Models
{
    public class SuperAdmin
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codSuperAdmin { get; set; }

        [MaxLength(50)]
        [Required]
        public string userSuperAdmin { get; set; }

        [MaxLength(50)]
        [Required]
        public string passwordSuperAdmin { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime lastLogin { get; set; }

        public void login()
        {
            lastLogin = DateTime.Now;
        }
    }
}
