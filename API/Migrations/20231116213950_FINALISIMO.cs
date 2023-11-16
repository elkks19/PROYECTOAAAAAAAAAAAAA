using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FINALISIMO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleOrden",
                table: "DetalleOrden");

            migrationBuilder.AddColumn<string>(
                name: "codDetalleOrden",
                table: "DetalleOrden",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrden_codProducto",
                table: "DetalleOrden");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleOrden",
                table: "DetalleOrden",
                column: "codDetalleOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_codOrden",
                table: "DetalleOrden",
                column: "codOrden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleOrden",
                table: "DetalleOrden");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrden_codOrden",
                table: "DetalleOrden");

            migrationBuilder.DropColumn(
                name: "codDetalleOrden",
                table: "DetalleOrden");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleOrden",
                table: "DetalleOrden",
                columns: new[] { "codOrden", "codProducto" });
        }
    }
}
