﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaFinal.Migrations
{
    /// <inheritdoc />
    public partial class Modelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
