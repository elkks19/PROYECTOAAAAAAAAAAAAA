using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FINAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    codCategoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombreCategoria = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
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
                    direccionEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archivoVerificacionEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    socialMediaEmprsa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
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
                    userPersona = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    passwordPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombrePersona = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    fechaNacPersona = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mailPersona = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    direccionPersona = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    celularPersona = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    pathFotoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.codPersona);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioProducto = table.Column<float>(type: "real", nullable: false),
                    precioEnvioProducto = table.Column<float>(type: "real", nullable: false),
                    pathFotoProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidadRestante = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
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
                name: "LogsAuditoria",
                columns: table => new
                {
                    codLog = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    accionLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaLog = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsAuditoria", x => x.codLog);
                    table.ForeignKey(
                        name: "FK_LogsAuditoria_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalEmpresa",
                columns: table => new
                {
                    codPersonalEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalEmpresa", x => x.codPersonalEmpresa);
                    table.ForeignKey(
                        name: "FK_PersonalEmpresa_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalEmpresa_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenGuardado",
                columns: table => new
                {
                    codToken = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    fechaCreacionToken = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenGuardado", x => x.codToken);
                    table.ForeignKey(
                        name: "FK_TokenGuardado_Persona_codPersona",
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
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
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
                name: "CategoriasPorProducto",
                columns: table => new
                {
                    codCategoria = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasPorProducto", x => new { x.codCategoria, x.codProducto });
                    table.ForeignKey(
                        name: "FK_CategoriasPorProducto_Categorias_codCategoria",
                        column: x => x.codCategoria,
                        principalTable: "Categorias",
                        principalColumn: "codCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriasPorProducto_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaEsperaEmpresa",
                columns: table => new
                {
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codAdmin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    isAceptado = table.Column<bool>(type: "bit", nullable: false),
                    fechaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    razonRevision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaSolicitudRevision = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaEsperaEmpresa", x => new { x.codEmpresa, x.codAdmin });
                    table.ForeignKey(
                        name: "FK_ListaEsperaEmpresa_Administradores_codAdmin",
                        column: x => x.codAdmin,
                        principalTable: "Administradores",
                        principalColumn: "codAdmin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaEsperaEmpresa_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuardadoCarrito",
                columns: table => new
                {
                    codGuardadoCarrito = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaGuardado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardadoCarrito", x => x.codGuardadoCarrito);
                    table.ForeignKey(
                        name: "FK_GuardadoCarrito_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuardadoCarrito_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuardadoWishlist",
                columns: table => new
                {
                    codGuardadoWishlist = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaGuardado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardadoWishlist", x => x.codGuardadoWishlist);
                    table.ForeignKey(
                        name: "FK_GuardadoWishlist_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuardadoWishlist_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    codLike = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaLike = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Orden",
                columns: table => new
                {
                    codOrden = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    direccionEntregaOrden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaEntregaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaPagoOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCancelada = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.codOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReclamosEmpresa",
                columns: table => new
                {
                    codReclamo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    contenidoReclamo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codAdmin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    isRevisado = table.Column<bool>(type: "bit", nullable: false),
                    fechaCreacionReclamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaRevisionReclamo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    respuestaReclamo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamosEmpresa", x => x.codReclamo);
                    table.ForeignKey(
                        name: "FK_ReclamosEmpresa_Administradores_codAdmin",
                        column: x => x.codAdmin,
                        principalTable: "Administradores",
                        principalColumn: "codAdmin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReclamosEmpresa_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReclamosEmpresa_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VisitasEmpresa",
                columns: table => new
                {
                    codVisita = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codEmpresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasEmpresa", x => x.codVisita);
                    table.ForeignKey(
                        name: "FK_VisitasEmpresa_Empresa_codEmpresa",
                        column: x => x.codEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "codEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitasEmpresa_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaAnadido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => new { x.codUsuario, x.codProducto });
                    table.ForeignKey(
                        name: "FK_Wishlist_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_Usuarios_codUsuario",
                        column: x => x.codUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "codUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    codDetalleOrden = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codOrden = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cantidadProducto = table.Column<int>(type: "int", nullable: false),
                    precioTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.codDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_codOrden",
                        column: x => x.codOrden,
                        principalTable: "Orden",
                        principalColumn: "codOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Producto_codProducto",
                        column: x => x.codProducto,
                        principalTable: "Producto",
                        principalColumn: "codProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_codPersona",
                table: "Administradores",
                column: "codPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_nombreCategoria",
                table: "Categorias",
                column: "nombreCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasPorProducto_codProducto",
                table: "CategoriasPorProducto",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_codOrden",
                table: "DetalleOrden",
                column: "codOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_codProducto",
                table: "DetalleOrden",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_nombreEmpresa",
                table: "Empresa",
                column: "nombreEmpresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuardadoCarrito_codProducto",
                table: "GuardadoCarrito",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_GuardadoCarrito_codUsuario",
                table: "GuardadoCarrito",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_GuardadoWishlist_codProducto",
                table: "GuardadoWishlist",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_GuardadoWishlist_codUsuario",
                table: "GuardadoWishlist",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Like_codProducto",
                table: "Like",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Like_codUsuario",
                table: "Like",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ListaEsperaEmpresa_codAdmin",
                table: "ListaEsperaEmpresa",
                column: "codAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_ListaEsperaEmpresa_codEmpresa",
                table: "ListaEsperaEmpresa",
                column: "codEmpresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogsAuditoria_codPersona",
                table: "LogsAuditoria",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_codUsuario",
                table: "Orden",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_mailPersona",
                table: "Persona",
                column: "mailPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_userPersona",
                table: "Persona",
                column: "userPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalEmpresa_codEmpresa",
                table: "PersonalEmpresa",
                column: "codEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalEmpresa_codPersona",
                table: "PersonalEmpresa",
                column: "codPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_codEmpresa",
                table: "Producto",
                column: "codEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamosEmpresa_codAdmin",
                table: "ReclamosEmpresa",
                column: "codAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamosEmpresa_codProducto",
                table: "ReclamosEmpresa",
                column: "codProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamosEmpresa_codUsuario",
                table: "ReclamosEmpresa",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TokenGuardado_codPersona",
                table: "TokenGuardado",
                column: "codPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TokenGuardado_Token",
                table: "TokenGuardado",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_codPersona",
                table: "Usuarios",
                column: "codPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitasEmpresa_codEmpresa",
                table: "VisitasEmpresa",
                column: "codEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasEmpresa_codUsuario",
                table: "VisitasEmpresa",
                column: "codUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_codProducto",
                table: "Wishlist",
                column: "codProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasPorProducto");

            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "GuardadoCarrito");

            migrationBuilder.DropTable(
                name: "GuardadoWishlist");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "ListaEsperaEmpresa");

            migrationBuilder.DropTable(
                name: "LogsAuditoria");

            migrationBuilder.DropTable(
                name: "PersonalEmpresa");

            migrationBuilder.DropTable(
                name: "ReclamosEmpresa");

            migrationBuilder.DropTable(
                name: "TokenGuardado");

            migrationBuilder.DropTable(
                name: "VisitasEmpresa");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
