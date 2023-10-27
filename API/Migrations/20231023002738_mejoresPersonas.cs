using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mejoresPersonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_codPersona",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personal_Empresa_codPersona",
                table: "Personal_Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_codPersona",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "apMaternoPersona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "apPaternoPersona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ciPersona",
                table: "Persona");

            migrationBuilder.AlterColumn<string>(
                name: "nombrePersona",
                table: "Persona",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_codPersona",
                table: "Usuarios",
                column: "codPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Empresa_codPersona",
                table: "Personal_Empresa",
                column: "codPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_codPersona",
                table: "Administradores",
                column: "codPersona",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_codPersona",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personal_Empresa_codPersona",
                table: "Personal_Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_codPersona",
                table: "Administradores");

            migrationBuilder.AlterColumn<string>(
                name: "nombrePersona",
                table: "Persona",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<string>(
                name: "apMaternoPersona",
                table: "Persona",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "apPaternoPersona",
                table: "Persona",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ciPersona",
                table: "Persona",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_codPersona",
                table: "Usuarios",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Empresa_codPersona",
                table: "Personal_Empresa",
                column: "codPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_codPersona",
                table: "Administradores",
                column: "codPersona");
        }
    }
}
