using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaFinal.Migrations
{
    /// <inheritdoc />
    public partial class tokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TokenGuardado",
                columns: table => new
                {
                    codToken = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    codPersona = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaCreacionToken = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenGuardado", x => x.codToken);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TokenGuardado");
        }
    }
}
