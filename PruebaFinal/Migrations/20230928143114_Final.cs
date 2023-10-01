using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaFinal.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    codCategoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombreCategoria = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.codCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombreEmpresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    direccionEmpresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.codEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombrePersona = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    apPaternoPersona = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    apMaternoPersona = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fechaNacPersona = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mailPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    direccionPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    passwordPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.codPersona);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    codAdmin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.codAdmin);
                    table.ForeignKey(
                        name: "FK_Administradores_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal_Empresa",
                columns: table => new
                {
                    codPersonalEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_Empresa", x => x.codPersonalEmpresa);
                    table.ForeignKey(
                        name: "FK_Personal_Empresa_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personal_Empresa_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    configUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.codUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lista_Espera_Empresa",
                columns: table => new
                {
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codAdmin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    isRevisado = table.Column<bool>(type: "bit", nullable: false),
                    fechaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaSolicitudRevision = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista_Espera_Empresa", x => new { x.codEmpresa, x.codAdmin });
                    table.ForeignKey(
                        name: "FK_Lista_Espera_Empresa_Administradores_codAdmin",
                        column: x => x.codAdmin,
                        principalTable: "Administradores",
                        principalColumn: "codAdmin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lista_Espera_Empresa_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    codOrden = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    direccionEntregaOrden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaEntregaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaPagoOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCancelada = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.codOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    codWishlist = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.codWishlist);
                    table.ForeignKey(
                        name: "FK_Wishlist_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    precioProducto = table.Column<float>(type: "real", nullable: false),
                    envioProducto = table.Column<float>(type: "real", nullable: false),
                    pathFotoProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrdencodOrden = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    WishlistcodWishlist = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.codProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Orden_OrdencodOrden",
                        column: x => x.OrdencodOrden,
                        principalTable: "Orden",
                        principalColumn: "codOrden");
                    table.ForeignKey(
                        name: "FK_Producto_Wishlist_WishlistcodWishlist",
                        column: x => x.WishlistcodWishlist,
                        principalTable: "Wishlist",
                        principalColumn: "codWishlist");
                });

            migrationBuilder.CreateTable(
                name: "Categorias_Por_Producto",
                columns: table => new
                {
                    codCategoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_Por_Producto", x => new { x.codCategoria, x.codProducto });
                    table.ForeignKey(
                        name: "FK_Categorias_Por_Producto_Categorias_codCategoria",
                        column: x => x.codCategoria,
                        principalTable: "Categorias",
                        principalColumn: "codCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categorias_Por_Producto_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    codComentario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    contenidoComentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.codComentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Orden",
                columns: table => new
                {
                    codOrden = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Orden", x => new { x.codOrden, x.codProducto });
                    table.ForeignKey(
                        name: "FK_Detalle_Orden_Orden_codOrden",
                        column: x => x.codOrden,
                        principalTable: "Orden",
                        principalColumn: "codOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Orden_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Wishlist",
                columns: table => new
                {
                    codWishlist = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaAnadido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCarrito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Wishlist", x => new { x.codWishlist, x.codProducto });
                    table.ForeignKey(
                        name: "FK_Detalle_Wishlist_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Wishlist_Wishlist_codWishlist",
                        column: x => x.codWishlist,
                        principalTable: "Wishlist",
                        principalColumn: "codWishlist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    codLike = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaLike = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.codLike);
                    table.ForeignKey(
                        name: "FK_Like_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reclamos_Empresa",
                columns: table => new
                {
                    codReclamo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    contenidoReclamo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    respuestaReclamo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codAdmin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    isRevisado = table.Column<bool>(type: "bit", nullable: false),
                    fechaCreacionReclamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaRevisionReclamo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamos_Empresa", x => x.codReclamo);
                    table.ForeignKey(
                        name: "FK_Reclamos_Empresa_Administradores_codAdmin",
                        column: x => x.codAdmin,
                        principalTable: "Administradores",
                        principalColumn: "codAdmin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reclamos_Empresa_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reclamos_Empresa_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_codPersona",
                table: "Administradores",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Por_Producto_codProducto",
                table: "Categorias_Por_Producto",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_codPersona",
                table: "Comentarios",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_codProducto",
                table: "Comentarios",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Orden_codProducto",
                table: "Detalle_Orden",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Wishlist_codProducto",
                table: "Detalle_Wishlist",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Like_codProducto",
                table: "Like",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Like_codUsuario",
                table: "Like",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_Espera_Empresa_codAdmin",
                table: "Lista_Espera_Empresa",
                column: "codAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_codEmpresa",
                table: "Orden",
                column: "codEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_codUsuario",
                table: "Orden",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Empresa_codEmpresa",
                table: "Personal_Empresa",
                column: "codEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Empresa_codPersona",
                table: "Personal_Empresa",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codEmpresa",
                table: "Producto",
                column: "codEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_OrdencodOrden",
                table: "Producto",
                column: "OrdencodOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_WishlistcodWishlist",
                table: "Producto",
                column: "WishlistcodWishlist");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_Empresa_codAdmin",
                table: "Reclamos_Empresa",
                column: "codAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_Empresa_codProducto",
                table: "Reclamos_Empresa",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_Empresa_codUsuario",
                table: "Reclamos_Empresa",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_codPersona",
                table: "Usuarios",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_codUsuario",
                table: "Wishlist",
                column: "codUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias_Por_Producto");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Detalle_Orden");

            migrationBuilder.DropTable(
                name: "Detalle_Wishlist");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Lista_Espera_Empresa");

            migrationBuilder.DropTable(
                name: "Personal_Empresa");

            migrationBuilder.DropTable(
                name: "Reclamos_Empresa");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
