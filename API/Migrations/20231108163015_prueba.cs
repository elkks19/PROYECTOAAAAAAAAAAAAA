using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Orden_OrdencodOrden",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Wishlist_WishlistcodWishlist",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_OrdencodOrden",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_WishlistcodWishlist",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "OrdencodOrden",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "WishlistcodWishlist",
                table: "Producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrdencodOrden",
                table: "Producto",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WishlistcodWishlist",
                table: "Producto",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_OrdencodOrden",
                table: "Producto",
                column: "OrdencodOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_WishlistcodWishlist",
                table: "Producto",
                column: "WishlistcodWishlist");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Orden_OrdencodOrden",
                table: "Producto",
                column: "OrdencodOrden",
                principalTable: "Orden",
                principalColumn: "codOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Wishlist_WishlistcodWishlist",
                table: "Producto",
                column: "WishlistcodWishlist",
                principalTable: "Wishlist",
                principalColumn: "codWishlist");
        }
    }
}
