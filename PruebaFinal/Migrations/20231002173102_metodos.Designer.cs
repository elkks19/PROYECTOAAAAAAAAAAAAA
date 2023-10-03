﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaFinal.Data;

#nullable disable

namespace PruebaFinal.Migrations
{
    [DbContext(typeof(PruebaFinalContext))]
    [Migration("20231002173102_metodos")]
    partial class metodos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebaFinal.Models.Administrador", b =>
                {
                    b.Property<string>("codAdmin")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codAdmin");

                    b.HasIndex("codPersona");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("PruebaFinal.Models.Categoria", b =>
                {
                    b.Property<string>("codCategoria")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("nombreCategoria")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("codCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("PruebaFinal.Models.Categorias_Por_Producto", b =>
                {
                    b.Property<string>("codCategoria")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("codCategoria", "codProducto");

                    b.HasIndex("codProducto");

                    b.ToTable("Categorias_Por_Producto");
                });

            modelBuilder.Entity("PruebaFinal.Models.Comentario", b =>
                {
                    b.Property<string>("codComentario")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("contenidoComentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("codComentario");

                    b.HasIndex("codPersona");

                    b.HasIndex("codProducto");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("PruebaFinal.Models.Detalle_Orden", b =>
                {
                    b.Property<string>("codOrden")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("cantidadProducto")
                        .HasColumnType("int");

                    b.Property<float>("precioTotal")
                        .HasColumnType("real");

                    b.HasKey("codOrden", "codProducto");

                    b.HasIndex("codProducto");

                    b.ToTable("Detalle_Orden");
                });

            modelBuilder.Entity("PruebaFinal.Models.Detalle_Wishlist", b =>
                {
                    b.Property<string>("codWishlist")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("fechaAnadido")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isCarrito")
                        .HasColumnType("bit");

                    b.HasKey("codWishlist", "codProducto");

                    b.HasIndex("codProducto");

                    b.ToTable("Detalle_Wishlist");
                });

            modelBuilder.Entity("PruebaFinal.Models.Empresa", b =>
                {
                    b.Property<string>("codEmpresa")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("direccionEmpresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("codEmpresa");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("PruebaFinal.Models.Like", b =>
                {
                    b.Property<string>("codLike")
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

                    b.Property<DateTime>("fechaLike")
                        .HasColumnType("datetime2");

                    b.HasKey("codLike");

                    b.HasIndex("codProducto");

                    b.HasIndex("codUsuario");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("PruebaFinal.Models.Lista_Espera_Empresa", b =>
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

                    b.Property<bool>("isRevisado")
                        .HasColumnType("bit");

                    b.HasKey("codEmpresa", "codAdmin");

                    b.HasIndex("codAdmin");

                    b.ToTable("Lista_Espera_Empresa");
                });

            modelBuilder.Entity("PruebaFinal.Models.Orden", b =>
                {
                    b.Property<string>("codOrden")
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

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("direccionEntregaOrden")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaEntregaOrden")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaPagoOrden")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isCancelada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("codOrden");

                    b.HasIndex("codEmpresa");

                    b.HasIndex("codUsuario");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("PruebaFinal.Models.Persona", b =>
                {
                    b.Property<string>("codPersona")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("apMaternoPersona")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("apPaternoPersona")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ciPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("direccionPersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("fechaNacPersona")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("mailPersona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombrePersona")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("passwordPersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("userPersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("codPersona");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("PruebaFinal.Models.Personal_Empresa", b =>
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

                    b.HasIndex("codPersona");

                    b.ToTable("Personal_Empresa");
                });

            modelBuilder.Entity("PruebaFinal.Models.Producto", b =>
                {
                    b.Property<string>("codProducto")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("OrdencodOrden")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("WishlistcodWishlist")
                        .HasColumnType("nvarchar(10)");

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

                    b.Property<float>("envioProducto")
                        .HasColumnType("real");

                    b.Property<DateTime>("lastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("pathFotoProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precioProducto")
                        .HasColumnType("real");

                    b.HasKey("codProducto");

                    b.HasIndex("OrdencodOrden");

                    b.HasIndex("WishlistcodWishlist");

                    b.HasIndex("codEmpresa");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PruebaFinal.Models.Reclamos_Empresa", b =>
                {
                    b.Property<string>("codReclamo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

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

                    b.ToTable("Reclamos_Empresa");
                });

            modelBuilder.Entity("PruebaFinal.Models.Usuario", b =>
                {
                    b.Property<string>("codUsuario")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("codPersona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("configUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codUsuario");

                    b.HasIndex("codPersona");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PruebaFinal.Models.Wishlist", b =>
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

            modelBuilder.Entity("PruebaFinal.Models.Administrador", b =>
                {
                    b.HasOne("PruebaFinal.Models.Persona", "Persona")
                        .WithMany("Administradores")
                        .HasForeignKey("codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("PruebaFinal.Models.Categorias_Por_Producto", b =>
                {
                    b.HasOne("PruebaFinal.Models.Categoria", "Categoria")
                        .WithMany("CategoriasProductos")
                        .HasForeignKey("codCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Producto", "Producto")
                        .WithMany("CategoriasProductos")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PruebaFinal.Models.Comentario", b =>
                {
                    b.HasOne("PruebaFinal.Models.Persona", "Persona")
                        .WithMany("Comentarios")
                        .HasForeignKey("codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Producto", "Producto")
                        .WithMany("Comentarios")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PruebaFinal.Models.Detalle_Orden", b =>
                {
                    b.HasOne("PruebaFinal.Models.Orden", "Orden")
                        .WithMany()
                        .HasForeignKey("codOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PruebaFinal.Models.Detalle_Wishlist", b =>
                {
                    b.HasOne("PruebaFinal.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Wishlist", "Wishlist")
                        .WithMany()
                        .HasForeignKey("codWishlist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("PruebaFinal.Models.Like", b =>
                {
                    b.HasOne("PruebaFinal.Models.Producto", "Producto")
                        .WithMany("Likes")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Usuario", "Usuario")
                        .WithMany("Likes")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PruebaFinal.Models.Lista_Espera_Empresa", b =>
                {
                    b.HasOne("PruebaFinal.Models.Administrador", "Administrador")
                        .WithMany("Lista_Espera_Empresas")
                        .HasForeignKey("codAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("PruebaFinal.Models.Orden", b =>
                {
                    b.HasOne("PruebaFinal.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Usuario", "Usuario")
                        .WithMany("Ordenes")
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PruebaFinal.Models.Personal_Empresa", b =>
                {
                    b.HasOne("PruebaFinal.Models.Empresa", "Empresa")
                        .WithMany("Personal")
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Persona", "Persona")
                        .WithMany("Personal_Empresas")
                        .HasForeignKey("codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("PruebaFinal.Models.Producto", b =>
                {
                    b.HasOne("PruebaFinal.Models.Orden", null)
                        .WithMany("Productos")
                        .HasForeignKey("OrdencodOrden");

                    b.HasOne("PruebaFinal.Models.Wishlist", null)
                        .WithMany("Productos")
                        .HasForeignKey("WishlistcodWishlist");

                    b.HasOne("PruebaFinal.Models.Empresa", "Empresa")
                        .WithMany("Productos")
                        .HasForeignKey("codEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("PruebaFinal.Models.Reclamos_Empresa", b =>
                {
                    b.HasOne("PruebaFinal.Models.Administrador", "Administrador")
                        .WithMany("Reclamos")
                        .HasForeignKey("codAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Producto", "Producto")
                        .WithMany("Reclamos")
                        .HasForeignKey("codProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaFinal.Models.Usuario", "Usuario")
                        .WithMany("Reclamos")
                        .HasForeignKey("codUsuario")
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PruebaFinal.Models.Usuario", b =>
                {
                    b.HasOne("PruebaFinal.Models.Persona", "Persona")
                        .WithMany("Usuarios")
                        .HasForeignKey("codPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("PruebaFinal.Models.Wishlist", b =>
                {
                    b.HasOne("PruebaFinal.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("codUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PruebaFinal.Models.Administrador", b =>
                {
                    b.Navigation("Lista_Espera_Empresas");

                    b.Navigation("Reclamos");
                });

            modelBuilder.Entity("PruebaFinal.Models.Categoria", b =>
                {
                    b.Navigation("CategoriasProductos");
                });

            modelBuilder.Entity("PruebaFinal.Models.Empresa", b =>
                {
                    b.Navigation("Personal");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("PruebaFinal.Models.Orden", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("PruebaFinal.Models.Persona", b =>
                {
                    b.Navigation("Administradores");

                    b.Navigation("Comentarios");

                    b.Navigation("Personal_Empresas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("PruebaFinal.Models.Producto", b =>
                {
                    b.Navigation("CategoriasProductos");

                    b.Navigation("Comentarios");

                    b.Navigation("Likes");

                    b.Navigation("Reclamos");
                });

            modelBuilder.Entity("PruebaFinal.Models.Usuario", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Ordenes");

                    b.Navigation("Reclamos");
                });

            modelBuilder.Entity("PruebaFinal.Models.Wishlist", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
