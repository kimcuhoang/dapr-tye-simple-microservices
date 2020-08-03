using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Migrations
{
    public partial class Init_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CanPurchase = table.Column<bool>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("a6e22a9f-286f-4767-9b5c-3a2be7d6e596"), "Inventory-1-Location", "Inventory-1" },
                    { new Guid("1730b960-4e6f-4d4f-9baf-be57fc4678e9"), "Inventory-2-Location", "Inventory-2" },
                    { new Guid("df6f5b85-a625-4f23-a08f-8daed0636ecc"), "Inventory-3-Location", "Inventory-3" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), "PRD-1" },
                    { new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), "PRD-2" },
                    { new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), "PRD-3" }
                });

            migrationBuilder.InsertData(
                table: "ProductInventory",
                columns: new[] { "Id", "CanPurchase", "InventoryId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("45b1c74d-7175-4de8-a41f-b02d48728745"), true, new Guid("a6e22a9f-286f-4767-9b5c-3a2be7d6e596"), new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), 10 },
                    { new Guid("6c82fd1d-238a-41d4-8957-06be16773531"), true, new Guid("1730b960-4e6f-4d4f-9baf-be57fc4678e9"), new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), 3 },
                    { new Guid("75adb09b-37de-4a56-9ae9-4abab87578fc"), true, new Guid("1730b960-4e6f-4d4f-9baf-be57fc4678e9"), new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), 1 },
                    { new Guid("a6b9f7f8-821a-4b61-802b-497d452f2a63"), true, new Guid("df6f5b85-a625-4f23-a08f-8daed0636ecc"), new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), 9 },
                    { new Guid("2d289c08-5b3d-44a1-b498-dd306702660d"), true, new Guid("a6e22a9f-286f-4767-9b5c-3a2be7d6e596"), new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), 5 },
                    { new Guid("b356a1c0-26a4-4af6-ad25-6db86ca21fb7"), true, new Guid("df6f5b85-a625-4f23-a08f-8daed0636ecc"), new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_InventoryId",
                table: "ProductInventory",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_ProductId",
                table: "ProductInventory",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInventory");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
