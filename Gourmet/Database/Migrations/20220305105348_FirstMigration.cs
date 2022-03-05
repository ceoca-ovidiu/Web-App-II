using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gourmet.Database.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", maxLength: 10000, nullable: false),
                    ProductPrice = table.Column<double>(type: "REAL", maxLength: 10000, nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: false),
                    ProductExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductExpirationDate", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[] { 1, "This is product 1 and it has some very interesting properties.", new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product number 1", 1.0, 21 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductExpirationDate", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[] { 2, "This is product 2 and it has some very interesting properties.", new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product number 2", 2.0, 22 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductExpirationDate", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[] { 3, "This is product 3 and it has some very interesting properties.", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product number 3", 3.0, 23 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductExpirationDate", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[] { 4, "This is product 4 and it has some very interesting properties.", new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product number 4", 4.0, 24 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
