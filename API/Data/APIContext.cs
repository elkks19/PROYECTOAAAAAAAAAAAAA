using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<API.Models.Usuario> Usuarios { get; set; } = default!;

        public DbSet<API.Models.Administrador> Administradores { get; set; } = default!;

        public DbSet<API.Models.Categoria> Categorias { get; set; } = default!;

        public DbSet<API.Models.Comentario> Comentarios { get; set; } = default!;

        public DbSet<API.Models.Persona> Persona { get; set; } = default!;

        public DbSet<API.Models.Orden> Orden { get; set; } = default!;

        public DbSet<API.Models.Producto> Producto { get; set; } = default!;

        public DbSet<API.Models.Empresa> Empresa { get; set; } = default!;

        public DbSet<API.Models.Detalle_Wishlist> Detalle_Wishlist { get; set; } = default!;

        public DbSet<API.Models.Categorias_Por_Producto> Categorias_Por_Producto { get; set; } = default!;

        public DbSet<API.Models.Detalle_Orden> Detalle_Orden { get; set; } = default!;

        public DbSet<API.Models.Reclamos_Empresa> Reclamos_Empresa { get; set; } = default!;

        public DbSet<API.Models.Wishlist> Wishlist { get; set; } = default!;

        public DbSet<API.Models.Personal_Empresa> Personal_Empresa { get; set; } = default!;

        public DbSet<API.Models.Lista_Espera_Empresa> Lista_Espera_Empresa { get; set; } = default!;

        public DbSet<API.Models.Like> Like { get; set; } = default!;

        public DbSet<API.Models.TokenGuardado> TokenGuardado { get; set; } = default!;


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

            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Token)
                .WithOne(x => x.Persona);

        }


    }
}
