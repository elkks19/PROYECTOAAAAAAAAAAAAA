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

        public DbSet<API.Models.VisitasEmpresa> VisitasEmpresa { get; set; } = default!;
        public DbSet<API.Models.GuardadoCarrito> GuardadoCarrito { get; set; } = default!;
        public DbSet<API.Models.GuardadoWishlist> GuardadoWishlist { get; set; } = default!;
        public DbSet<API.Models.Usuario> Usuarios { get; set; } = default!;
        public DbSet<API.Models.LogAuditoria> LogsAuditoria { get; set; } = default!;
        public DbSet<API.Models.Administrador> Administradores { get; set; } = default!;
        public DbSet<API.Models.Categoria> Categorias { get; set; } = default!;
        public DbSet<API.Models.Comentario> Comentarios { get; set; } = default!;
        public DbSet<API.Models.Persona> Persona { get; set; } = default!;
        public DbSet<API.Models.Orden> Orden { get; set; } = default!;
        public DbSet<API.Models.Producto> Producto { get; set; } = default!;
        public DbSet<API.Models.Empresa> Empresa { get; set; } = default!;
        public DbSet<API.Models.DetalleWishlist> DetalleWishlist { get; set; } = default!;
        public DbSet<API.Models.CategoriasPorProducto> CategoriasPorProducto { get; set; } = default!;
        public DbSet<API.Models.DetalleOrden> DetalleOrden { get; set; } = default!;
        public DbSet<API.Models.ReclamosEmpresa> ReclamosEmpresa { get; set; } = default!;
        public DbSet<API.Models.Wishlist> Wishlist { get; set; } = default!;
        public DbSet<API.Models.PersonalEmpresa> PersonalEmpresa { get; set; } = default!;
        public DbSet<API.Models.ListaEsperaEmpresa> ListaEsperaEmpresa { get; set; } = default!;
        public DbSet<API.Models.Like> Like { get; set; } = default!;
        public DbSet<API.Models.TokenGuardado> TokenGuardado { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cosas que deberian ser unique
            modelBuilder.Entity<Persona>()
                .HasIndex(x => x.userPersona)
                .IsUnique();
            modelBuilder.Entity<Persona>()
                .HasIndex(x => x.mailPersona)
                .IsUnique();
            modelBuilder.Entity<Categoria>()
                .HasIndex(x => x.nombreCategoria)
                .IsUnique();
            modelBuilder.Entity<Empresa>()
                .HasIndex(x => x.nombreEmpresa)
                .IsUnique();
            modelBuilder.Entity<ListaEsperaEmpresa>()
                .HasIndex(x => x.codEmpresa)
                .IsUnique();
            modelBuilder.Entity<TokenGuardado>()
                .HasIndex(x => x.Token)
                .IsUnique();

            // claves compuestas
            modelBuilder.Entity<CategoriasPorProducto>()
                .HasKey(x => new { x.codCategoria, x.codProducto });
            modelBuilder.Entity<DetalleOrden>()
                .HasKey(x => new { x.codOrden, x.codProducto });
            modelBuilder.Entity<DetalleWishlist>()
                .HasKey(x => new { x.codWishlist, x.codProducto });
            modelBuilder.Entity<ListaEsperaEmpresa>()
                .HasKey(x => new { x.codEmpresa, x.codAdmin });



            // Relaciones Persona con las subclases
            // USUARIO
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Usuario)
                .WithOne(x => x.Persona);
            // ADMINISTRADOR
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Administrador)
                .WithOne(x => x.Persona);
            // PERSONAL
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.PersonalEmpresa)
                .WithOne(x => x.Persona);
            // COMENTARIOS
            modelBuilder.Entity<Persona>()
                .HasMany(x => x.Comentarios)
                .WithOne(x => x.Persona);
            // LOGS
            modelBuilder.Entity<Persona>()
                .HasMany(x => x.Logs)
                .WithOne(x => x.Persona);
            // TOKEN
            modelBuilder.Entity<Persona>()
                .HasOne(x => x.Token)
                .WithOne(x => x.Persona);


            // Relaciones Administrador
            // LISTA ESPERA
            modelBuilder.Entity<Administrador>()
                .HasMany(x => x.ListaEsperaEmpresas)
                .WithOne(x => x.Administrador);
            // RECLAMOS
            modelBuilder.Entity<Administrador>()
                .HasMany(x => x.Reclamos)
                .WithOne(x => x.Administrador);


            // Relaciones Productos
            // COMENTARIOS
            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Comentarios)
                .WithOne(x => x.Producto);
            // RECLAMOS 
            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Reclamos)
                .WithOne(x => x.Producto);
            // COMENTARIOS
            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Likes)
                .WithOne(x => x.Producto);


            // Relaciones Empresa
            // PERSONAL
            modelBuilder.Entity<Empresa>()
                .HasMany(x => x.Personal)
                .WithOne(x => x.Empresa);
            // PRODUCTOS
            modelBuilder.Entity<Empresa>()
                .HasMany(x => x.Productos)
                .WithOne(x => x.Empresa);
            // LISTA_ESPERA
            modelBuilder.Entity<Empresa>()
                .HasOne(x => x.ListaEspera)
                .WithOne(x => x.Empresa);
            // ORDENES
            modelBuilder.Entity<Empresa>()
                .HasMany(x => x.Ordenes)
                .WithOne(x => x.Empresa);
            // VISITAS
            modelBuilder.Entity<Empresa>()
                .HasMany(x => x.Visitas)
                .WithOne(x => x.Empresa);


            // Relaciones Usuario
            // LIKES
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Likes)
                .WithOne(x => x.Usuario);
            // ORDENES 
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Ordenes)
                .WithOne(x => x.Usuario);
            // RECLAMOS 
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.Reclamos)
                .WithOne(x => x.Usuario);
            // GUARDADOCARRITO 
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.GuardadoCarrito)
                .WithOne(x => x.Usuario);
            // GUARDADOWISHLIST
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.GuardadoWishlist)
                .WithOne(x => x.Usuario);
            // VISITASEMPRESA
            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.VisitasEmpresa)
                .WithOne(x => x.Usuario);







            // M:N Categorias - Productos
            // PRODUCTOS
            modelBuilder.Entity<Producto>()
                .HasMany(x => x.CategoriasProductos)
                .WithOne(x => x.Producto);
            // CATEGORIAS
            modelBuilder.Entity<Categoria>()
                .HasMany(x => x.CategoriasProductos)
                .WithOne(x => x.Categoria);

            // M:N Producto - DetalleOrden
            // ORDEN
            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Ordenes)
                .WithOne(x => x.Producto);
            // PRODUCTO
            modelBuilder.Entity<Orden>()
                .HasMany(x => x.Ordenes)
                .WithOne(x => x.Orden);

            // M:N Producto - DetalleWishlist
            // ORDEN
            modelBuilder.Entity<Wishlist>()
                .HasMany(x => x.Wishlists)
                .WithOne(x => x.Wishlist);
            // PRODUCTO
            modelBuilder.Entity<Producto>()
                .HasMany(x => x.Wishlists)
                .WithOne(x => x.Producto);

        }


    }
}
