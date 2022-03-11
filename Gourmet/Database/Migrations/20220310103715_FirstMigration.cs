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
                name: "ProductsDbSet",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", maxLength: 10000, nullable: false),
                    ProductPrice = table.Column<double>(type: "REAL", maxLength: 10000, nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: false),
                    ProductImage = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDbSet", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "UsersDbSet",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserPassword = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserImage = table.Column<byte[]>(type: "BLOB", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDbSet", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "RecipesDbSet",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecipeDescription = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecipeImage = table.Column<byte[]>(type: "BLOB", maxLength: 100, nullable: false),
                    RecipeProductReferenceProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipesDbSet", x => x.RecipeID);
                    table.ForeignKey(
                        name: "FK_RecipesDbSet_ProductsDbSet_RecipeProductReferenceProductId",
                        column: x => x.RecipeProductReferenceProductId,
                        principalTable: "ProductsDbSet",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipesDbSet_RecipeProductReferenceProductId",
                table: "RecipesDbSet",
                column: "RecipeProductReferenceProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipesDbSet");

            migrationBuilder.DropTable(
                name: "UsersDbSet");

            migrationBuilder.DropTable(
                name: "ProductsDbSet");
        }
    }
}
