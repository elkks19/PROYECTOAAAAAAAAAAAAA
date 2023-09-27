using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaMVC.Migrations
{
    /// <inheritdoc />
    public partial class fkpruebas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombrePersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apPaternoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apMaternoPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNacPewsona = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mailPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccionPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordPersona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.codPersona);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    codUsuario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    configuracionUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PersonacodPersona = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.codUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonacodPersona",
                        column: x => x.PersonacodPersona,
                        principalTable: "Personas",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonacodPersona",
                table: "Usuarios",
                column: "PersonacodPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
