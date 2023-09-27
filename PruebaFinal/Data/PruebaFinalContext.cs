using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaFinal.Models;

namespace PruebaFinal.Data
{
    public class PruebaFinalContext : DbContext
    {
        public PruebaFinalContext (DbContextOptions<PruebaFinalContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaFinal.Models.Usuario> Usuarios { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Administrador> Administradores { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Categoria> Categorias { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Comentario> Comentarios { get; set; } = default!;
    }
}
