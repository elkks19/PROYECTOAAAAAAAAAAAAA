﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(APIContext))]
    partial class APIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Administrador", b =>
                {
                    b.Property<string>("codAdmin")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codAdmin");

                    b.HasIndex("codPersona")
                        .IsUnique();

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("API.Models.Categoria", b =>
                {
                    b.Property<string>("codCategoria")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("nombreCategoria")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("codCategoria");

                    b.HasIndex("nombreCategoria")
                        .IsUnique();

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("API.Models.CategoriasPorProducto", b =>
                {
                    b.Property<string>("codCategoria")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codCategoria", "codProducto");

                    b.HasIndex("codProducto");

                    b.ToTable("CategoriasPorProducto");
                });

            modelBuilder.Entity("API.Models.DetalleOrden", b =>
                {
                    b.Property<string>("codDetalleOrden")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("cantidadProducto")
                        .HasColumnType("int");

                    b.Property<string>("codOrden")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("precioTotal")
                        .HasColumnType("real");

                    b.HasKey("codDetalleOrden");

                    b.HasIndex("codOrden");

                    b.HasIndex("codProducto");

                    b.ToTable("DetalleOrden");
                });

            modelBuilder.Entity("API.Models.DetalleWishlist", b =>
                {
                    b.Property<string>("codWishlist")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaAnadido")
                        .HasColumnType("datetime2");

                    b.HasKey("codWishlist", "codProducto");

                    b.HasIndex("codProducto");

                    b.ToTable("DetalleWishlist");
                });

            modelBuilder.Entity("API.Models.Empresa", b =>
                {
                    b.Property<string>("codEmpresa")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("archivoVerificacionEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("direccionEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("socialMediaEmprsa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codEmpresa");

                    b.HasIndex("nombreEmpresa")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("API.Models.GuardadoCarrito", b =>
                {
                    b.Property<string>("codGuardadoCarrito")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaGuardado")
                        .HasColumnType("datetime2");

                    b.HasKey("codGuardadoCarrito");

                    b.HasIndex("codProducto");

                    b.HasIndex("codUsuario");

                    b.ToTable("GuardadoCarrito");
                });

            modelBuilder.Entity("API.Models.GuardadoWishlist", b =>
                {
                    b.Property<string>("codGuardadoWishlist")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaGuardado")
                        .HasColumnType("datetime2");

                    b.HasKey("codGuardadoWishlist");

                    b.HasIndex("codProducto");

                    b.HasIndex("codUsuario");

                    b.ToTable("GuardadoWishlist");
                });

            modelBuilder.Entity("API.Models.Like", b =>
                {
                    b.Property<string>("codLike")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("codProducto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaLike")
                        .HasColumnType("datetime2");

                    b.HasKey("codLike");

                    b.HasIndex("codProducto");

                    b.HasIndex("codUsuario");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("API.Models.ListaEsperaEmpresa", b =>
                {
                    b.Property<string>("codEmpresa")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codAdmin")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("fechaRevision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaSolicitudRevision")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isAceptado")
                        .HasColumnType("bit");

                    b.Property<string>("razonRevision")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codEmpresa", "codAdmin");

                    b.HasIndex("codAdmin");

                    b.HasIndex("codEmpresa")
                        .IsUnique();

                    b.ToTable("ListaEsperaEmpresa");
                });

            modelBuilder.Entity("API.Models.LogAuditoria", b =>
                {
                    b.Property<string>("codLog")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("accionLog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaLog")
                        .HasColumnType("datetime2");

                    b.HasKey("codLog");

                    b.HasIndex("codPersona");

                    b.ToTable("LogsAuditoria");
                });

            modelBuilder.Entity("API.Models.Orden", b =>
                {
                    b.Property<string>("codOrden")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("direccionEntregaOrden")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("fechaEntregaOrden")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaPagoOrden")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool>("isCancelada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("codOrden");

                    b.HasIndex("codUsuario");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("API.Models.Persona", b =>
                {
                    b.Property<string>("codPersona")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("celularPersona")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("direccionPersona")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime>("fechaNacPersona")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("mailPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nombrePersona")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("passwordPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pathFotoPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("codPersona");

                    b.HasIndex("mailPersona")
                        .IsUnique();

                    b.HasIndex("userPersona")
                        .IsUnique();

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("API.Models.PersonalEmpresa", b =>
                {
                    b.Property<string>("codPersonalEmpresa")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codEmpresa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codPersonalEmpresa");

                    b.HasIndex("codEmpresa");

                    b.HasIndex("codPersona")
                        .IsUnique();

                    b.ToTable("PersonalEmpresa");
                });

            modelBuilder.Entity("API.Models.Producto", b =>
                {
                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<int>("cantidadRestante")
                        .HasColumnType("int");

                    b.Property<string>("codEmpresa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("descProducto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("pathFotoProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precioEnvioProducto")
                        .HasColumnType("real");

                    b.Property<float>("precioProducto")
                        .HasColumnType("real");

                    b.HasKey("codProducto");

                    b.HasIndex("codEmpresa");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("API.Models.ReclamosEmpresa", b =>
                {
                    b.Property<string>("codReclamo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("codAdmin")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("contenidoReclamo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaCreacionReclamo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaRevisionReclamo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRevisado")
                        .HasColumnType("bit");

                    b.Property<string>("respuestaReclamo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codReclamo");

                    b.HasIndex("codAdmin");

                    b.HasIndex("codProducto");

                    b.HasIndex("codUsuario");

                    b.ToTable("ReclamosEmpresa");
                });

            modelBuilder.Entity("API.Models.TokenGuardado", b =>
                {
                    b.Property<string>("codToken")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaCreacionToken")
                        .HasColumnType("datetime2");

                    b.HasKey("codToken");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.HasIndex("codPersona")
                        .IsUnique();

                    b.ToTable("TokenGuardado");
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.Property<string>("codUsuario")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codUsuario");

                    b.HasIndex("codPersona")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API.Models.VisitasEmpresa", b =>
                {
                    b.Property<string>("codVisita")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codEmpresa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaVisita")
                        .HasColumnType("datetime2");

                    b.HasKey("codVisita");

                    b.HasIndex("codEmpresa");

                    b.HasIndex("codUsuario");

                    b.ToTable("VisitasEmpresa");
                });

            modelBuilder.Entity("API.Models.Wishlist", b =>
                {
                    b.Property<string>("codWishlist")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codUsuario")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codWishlist");

                    b.HasIndex("codUsuario");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("API.Models.Administrador", b =>
                {
                    b.HasOne("API.Models.Persona", "Persona")
                        .WithOne("Administrador")
                        .HasForeignKey("API.Models.Administrador", "codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("API.Models.CategoriasPorProducto", b =>
                {
                    b.HasOne("API.Models.Categoria", "Categoria")
                        .WithMany("CategoriasProductos")
                        .HasForeignKey("codCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany("CategoriasProductos")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("API.Models.DetalleOrden", b =>
                {
                    b.HasOne("API.Models.Orden", "Orden")
                        .WithMany("Ordenes")
                        .HasForeignKey("codOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany("Ordenes")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("API.Models.DetalleWishlist", b =>
                {
                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany("Wishlists")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Wishlist", "Wishlist")
                        .WithMany("Wishlists")
                        .HasForeignKey("codWishlist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("API.Models.GuardadoCarrito", b =>
                {
                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany("GuardadoCarrito")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.GuardadoWishlist", b =>
                {
                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany("GuardadoWishlist")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.Like", b =>
                {
                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany("Likes")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany("Likes")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.ListaEsperaEmpresa", b =>
                {
                    b.HasOne("API.Models.Administrador", "Administrador")
                        .WithMany("ListaEsperaEmpresas")
                        .HasForeignKey("codAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Empresa", "Empresa")
                        .WithOne("ListaEspera")
                        .HasForeignKey("API.Models.ListaEsperaEmpresa", "codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("API.Models.LogAuditoria", b =>
                {
                    b.HasOne("API.Models.Persona", "Persona")
                        .WithMany("Logs")
                        .HasForeignKey("codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("API.Models.Orden", b =>
                {
                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany("Ordenes")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.PersonalEmpresa", b =>
                {
                    b.HasOne("API.Models.Empresa", "Empresa")
                        .WithMany("Personal")
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Persona", "Persona")
                        .WithOne("PersonalEmpresa")
                        .HasForeignKey("API.Models.PersonalEmpresa", "codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("API.Models.Producto", b =>
                {
                    b.HasOne("API.Models.Empresa", "Empresa")
                        .WithMany("Productos")
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("API.Models.ReclamosEmpresa", b =>
                {
                    b.HasOne("API.Models.Administrador", "Administrador")
                        .WithMany("Reclamos")
                        .HasForeignKey("codAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Producto", "Producto")
                        .WithMany("Reclamos")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany("Reclamos")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.TokenGuardado", b =>
                {
                    b.HasOne("API.Models.Persona", "Persona")
                        .WithOne("Token")
                        .HasForeignKey("API.Models.TokenGuardado", "codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.HasOne("API.Models.Persona", "Persona")
                        .WithOne("Usuario")
                        .HasForeignKey("API.Models.Usuario", "codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("API.Models.VisitasEmpresa", b =>
                {
                    b.HasOne("API.Models.Empresa", "Empresa")
                        .WithMany("Visitas")
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany("VisitasEmpresa")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.Wishlist", b =>
                {
                    b.HasOne("API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.Models.Administrador", b =>
                {
                    b.Navigation("ListaEsperaEmpresas");

                    b.Navigation("Reclamos");
                });

            modelBuilder.Entity("API.Models.Categoria", b =>
                {
                    b.Navigation("CategoriasProductos");
                });

            modelBuilder.Entity("API.Models.Empresa", b =>
                {
                    b.Navigation("ListaEspera")
                        .IsRequired();

                    b.Navigation("Personal");

                    b.Navigation("Productos");

                    b.Navigation("Visitas");
                });

            modelBuilder.Entity("API.Models.Orden", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("API.Models.Persona", b =>
                {
                    b.Navigation("Administrador")
                        .IsRequired();

                    b.Navigation("Logs");

                    b.Navigation("PersonalEmpresa")
                        .IsRequired();

                    b.Navigation("Token")
                        .IsRequired();

                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Producto", b =>
                {
                    b.Navigation("CategoriasProductos");

                    b.Navigation("Likes");

                    b.Navigation("Ordenes");

                    b.Navigation("Reclamos");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("API.Models.Usuario", b =>
                {
                    b.Navigation("GuardadoCarrito");

                    b.Navigation("GuardadoWishlist");

                    b.Navigation("Likes");

                    b.Navigation("Ordenes");

                    b.Navigation("Reclamos");

                    b.Navigation("VisitasEmpresa");
                });

            modelBuilder.Entity("API.Models.Wishlist", b =>
                {
                    b.Navigation("Wishlists");
                });
#pragma warning restore 612, 618
        }
    }
}
