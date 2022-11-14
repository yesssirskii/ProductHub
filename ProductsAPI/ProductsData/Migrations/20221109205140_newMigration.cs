using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsData.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeForeignKey",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeForeignKey",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductTypeForeignKey",
                table: "Products",
                newName: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "ProductTypeForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeForeignKey",
                table: "Products",
                column: "ProductTypeForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeForeignKey",
                table: "Products",
                column: "ProductTypeForeignKey",
                principalTable: "ProductTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
