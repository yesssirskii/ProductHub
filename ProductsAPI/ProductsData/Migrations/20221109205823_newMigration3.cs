using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsData.Migrations
{
    public partial class newMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeTypeId",
                table: "Products",
                column: "ProductTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeTypeId",
                table: "Products",
                column: "ProductTypeTypeId",
                principalTable: "ProductTypes",
                principalColumn: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeTypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "TypeId");
        }
    }
}
