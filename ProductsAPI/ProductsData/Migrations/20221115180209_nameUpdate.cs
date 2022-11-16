using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsData.Migrations
{
    /// <inheritdoc />
    public partial class nameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ProductTypes",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Products",
                newName: "productTypeid");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Products",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                newName: "IX_Products_productTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_productTypeid",
                table: "Products",
                column: "productTypeid",
                principalTable: "ProductTypes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_productTypeid",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "ProductTypes",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "productTypeid",
                table: "Products",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Products",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_productTypeid",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id");
        }
    }
}
