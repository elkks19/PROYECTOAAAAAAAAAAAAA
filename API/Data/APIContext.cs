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
        public DbSet<API.Models.Log_Auditoria> Logs_Auditoria { get; set; } = default!;

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
            modelBuilder.Entity<Persona>()
                .HasMany(x => x.Logs)
                .WithOne(x => x.Persona);

            modelBuilder.Entity<Empresa>()
                .HasMany(x => x.Personal)
                .WithOne(x => x.Empresa);

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

            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Ordenes)
                .WithOne(x => x.Producto);

            modelBuilder.Entity<Wishlist>()
                .HasMany(x => x.Productos)
                .WithOne(x => x.Wishlist);

            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Wishlists)
                .WithOne(x => x.Producto);

            modelBuilder.Entity<Orden>()
                .HasMany(x => x.Productos)
                .WithOne(x => x.Orden);

            modelBuilder.Entity<Lista_Espera_Empresa>()
                .HasKey(x => new { x.codEmpresa, x.codAdmin });

            modelBuilder.Entity<Lista_Espera_Empresa>()
                .HasOne(x => x.Empresa)
                .WithOne(x => x.ListaEspera);

            modelBuilder.Entity<Empresa>()
                .HasOne(x => x.ListaEspera)
                .WithOne(x => x.Empresa);

            modelBuilder.Entity<Administrador>()
                .HasMany(x => x.Lista_Espera_Empresas)
                .WithOne(x => x.Administrador);

            modelBuilder.Entity<Lista_Espera_Empresa>()
                .HasOne(x => x.Administrador)
                .WithMany(x => x.Lista_Espera_Empresas);


            modelBuilder.Entity<Reclamos_Empresa>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Reclamos)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Token)
                .WithOne(x => x.Persona);
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Usuario)
                .WithOne(x => x.Persona);
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Personal_Empresa)
                .WithOne(x => x.Persona);
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Administrador)
                .WithOne(x => x.Persona);

            modelBuilder.Entity<Usuario>()
                .HasOne(x => x.Persona)
                .WithOne(x => x.Usuario);
        }


    }
}
