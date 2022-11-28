using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductsData.Migrations
{
    /// <inheritdoc />
    public partial class init00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productTypeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_productTypeid",
                        column: x => x.productTypeid,
                        principalTable: "ProductTypes",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "Kitchen Utensils" },
                    { 2, "Transportation" },
                    { 3, "Jewlery" },
                    { 4, "Consumables" },
                    { 5, "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "country", "name", "price", "productTypeid" },
                values: new object[,]
                {
                    { 1, "COLOMBIA", "Spoon", 32, null },
                    { 2, "CROATIA", "Bycicle", 569, null },
                    { 3, "ITALY", "Necklace", 1600, null },
                    { 4, "FRANCE", "Water", 5, null },
                    { 5, "ITALY", "Chair", 260, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_productTypeid",
                table: "Products",
                column: "productTypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
