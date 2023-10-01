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

        public DbSet<PruebaFinal.Models.Persona> Persona { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Orden> Orden { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Producto> Producto { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Empresa> Empresa { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Detalle_Wishlist> Detalle_Wishlist { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Categorias_Por_Producto> Categorias_Por_Producto { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Detalle_Orden> Detalle_Orden { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Reclamos_Empresa> Reclamos_Empresa { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Wishlist> Wishlist { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Personal_Empresa> Personal_Empresa { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Lista_Espera_Empresa> Lista_Espera_Empresa { get; set; } = default!;

        public DbSet<PruebaFinal.Models.Like> Like { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias_Por_Producto>()
                .HasKey(x => new { x.codCategoria, x.codProducto });

            modelBuilder.Entity<Producto>()
                .HasMany(x => x.CategoriasProductos)
                .WithOne(x => x.Producto);

            modelBuilder.Entity<Categorias_Por_Producto>()
                .HasOne(x => x.Producto)
                .WithMany(x => x.CategoriasProductos);


            modelBuilder.Entity<Categoria>()
                .HasMany(x => x.CategoriasProductos)
                .WithOne(x => x.Categoria);

            modelBuilder.Entity<Categorias_Por_Producto>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.CategoriasProductos);



            modelBuilder.Entity<Detalle_Orden>()
                .HasKey(x => new { x.codOrden, x.codProducto });



            modelBuilder.Entity<Detalle_Wishlist>()
                .HasKey(x => new { x.codWishlist, x.codProducto });


            modelBuilder.Entity<Comentario>()
                .HasOne(x => x.Producto)
                .WithMany(x => x.Comentarios);

            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Comentarios)
                .WithOne(x => x.Producto);



            modelBuilder.Entity<Lista_Espera_Empresa>()
                .HasKey(x => new { x.codEmpresa, x.codAdmin });

            modelBuilder.Entity<Administrador>()
                .HasMany(x => x.Lista_Espera_Empresas)
                .WithOne(x => x.Administrador);


            modelBuilder.Entity<Reclamos_Empresa>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Reclamos)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }

    }
}
