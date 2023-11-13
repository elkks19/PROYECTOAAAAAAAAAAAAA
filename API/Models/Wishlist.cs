﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Wishlist
    {
        [MaxLength(10)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string codWishlist { get; set; }

        [MaxLength(10)]
        [Required]
        public string codUsuario { get; set; }
        [ForeignKey("codUsuario")]
        public Usuario Usuario { get; set; }

        public ICollection<DetalleWishlist> Wishlists { get; set; }
    }
}
