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
                    ProductInventoryId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CanPurchase = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => x.ProductInventoryId);
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
                    { new Guid("3b709167-9e2f-44cb-961e-9d7bcf77d91b"), "Inventory-1-Location", "Inventory-1" },
                    { new Guid("8ba6e9b7-950f-47ca-abd2-39bf58f09b1f"), "Inventory-2-Location", "Inventory-2" },
                    { new Guid("b11291e8-6366-4a50-8ae2-816c80cb11da"), "Inventory-3-Location", "Inventory-3" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("b166e6e6-c0fb-45d4-8aa0-b5749800c706"), "PRD-1" },
                    { new Guid("e3766653-91dd-4cac-8a83-c736b2d6b349"), "PRD-2" },
                    { new Guid("cf9dfebe-8cd8-4356-9edd-04e74d4618a3"), "PRD-3" }
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
