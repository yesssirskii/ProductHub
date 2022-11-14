using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsData.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTypeForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeForeignKey",
                        column: x => x.ProductTypeForeignKey,
                        principalTable: "ProductTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "TypeId", "Type" },
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
                columns: new[] { "ProductId", "Country", "Name", "Price", "ProductTypeForeignKey" },
                values: new object[,]
                {
                    { 1, "COLOMBIA", "Spoon", 32, 1 },
                    { 2, "CROATIA", "Bycicle", 569, 2 },
                    { 3, "ITALY", "Necklace", 1600, 3 },
                    { 4, "FRANCE", "Water", 5, 4 },
                    { 5, "ITALY", "Chair", 260, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeForeignKey",
                table: "Products",
                column: "ProductTypeForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
