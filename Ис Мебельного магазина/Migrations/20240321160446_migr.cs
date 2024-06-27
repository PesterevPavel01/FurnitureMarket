using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ис_Мебельного_магазина.Migrations
{
    /// <inheritdoc />
    public partial class migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ExtraCharge = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePost = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Salage = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PercentageOfSales = table.Column<int>(type: "int", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "providers",
                columns: table => new
                {
                    IdProvider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    Fax = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    Inn = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    NameProvider = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    additionally = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providers", x => x.IdProvider);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PositionCode = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BirthDay = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "PostId");
                });

            migrationBuilder.CreateTable(
                name: "purchaseOfGoods",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasePrise = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    PurchaseVolume = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PurchaseType = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PurchaseDescription = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    providersIdProvider = table.Column<int>(type: "int", nullable: true),
                    categoriesCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseOfGoods", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_purchaseOfGoods_categories_categoriesCategoryId",
                        column: x => x.categoriesCategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_purchaseOfGoods_providers_providersIdProvider",
                        column: x => x.providersIdProvider,
                        principalTable: "providers",
                        principalColumn: "IdProvider");
                });

            migrationBuilder.CreateTable(
                name: "realizations",
                columns: table => new
                {
                    RealizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    total = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", maxLength: 40, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOfGoodsPurchaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realizations", x => x.RealizationId);
                    table.ForeignKey(
                        name: "FK_realizations_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_realizations_purchaseOfGoods_PurchaseOfGoodsPurchaseId",
                        column: x => x.PurchaseOfGoodsPurchaseId,
                        principalTable: "purchaseOfGoods",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_PostId",
                table: "employees",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOfGoods_categoriesCategoryId",
                table: "purchaseOfGoods",
                column: "categoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOfGoods_providersIdProvider",
                table: "purchaseOfGoods",
                column: "providersIdProvider");

            migrationBuilder.CreateIndex(
                name: "IX_realizations_EmployeeId",
                table: "realizations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_realizations_PurchaseOfGoodsPurchaseId",
                table: "realizations",
                column: "PurchaseOfGoodsPurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "realizations");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "purchaseOfGoods");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "providers");
        }
    }
}
