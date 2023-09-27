using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaMVC.Migrations
{
    /// <inheritdoc />
    public partial class pruebaBOOls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActivo",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActivo",
                table: "Personas");
        }
    }
}
