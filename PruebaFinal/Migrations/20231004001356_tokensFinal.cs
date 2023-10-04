using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaFinal.Migrations
{
    /// <inheritdoc />
    public partial class tokensFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TokenGuardado_codPersona",
                table: "TokenGuardado",
                column: "codPersona",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TokenGuardado_Persona_codPersona",
                table: "TokenGuardado",
                column: "codPersona",
                principalTable: "Persona",
                principalColumn: "codPersona",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokenGuardado_Persona_codPersona",
                table: "TokenGuardado");

            migrationBuilder.DropIndex(
                name: "IX_TokenGuardado_codPersona",
                table: "TokenGuardado");
        }
    }
}
