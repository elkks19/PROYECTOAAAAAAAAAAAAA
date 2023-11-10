using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs_Auditoria",
                columns: table => new
                {
                    codLog = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    accionLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaLog = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs_Auditoria", x => x.codLog);
                    table.ForeignKey(
                        name: "FK_Logs_Auditoria_Persona_codPersona",
                        column: x => x.codPersona,
                        principalTable: "Persona",
                        principalColumn: "codPersona",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lista_Espera_Empresa_codEmpresa",
                table: "Lista_Espera_Empresa",
                column: "codEmpresa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_Auditoria_codPersona",
                table: "Logs_Auditoria",
                column: "codPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs_Auditoria");

            migrationBuilder.DropIndex(
                name: "IX_Lista_Espera_Empresa_codEmpresa",
                table: "Lista_Espera_Empresa");
        }
    }
}
