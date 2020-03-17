using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Migrations
{
    public partial class Init_DB : Migration
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
                    Quantity = table.Column<int>(nullable: false),
                    CanPurchase = table.Column<bool>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false)
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
                    { new Guid("7aa9115d-00d9-4215-98fa-cbd9aceb0744"), "Inventory-1-Location", "Inventory-1" },
                    { new Guid("db9af98a-2a0e-4888-9cab-2b9d018bdf88"), "Inventory-2-Location", "Inventory-2" },
                    { new Guid("2bd3355c-e658-4973-9c30-008f85d103bb"), "Inventory-3-Location", "Inventory-3" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("15f110f6-38e8-4a21-a344-e5f164f233d6"), "PRD-1" },
                    { new Guid("3d7c9d9b-d889-40f0-963c-643f9ec28d0c"), "PRD-2" },
                    { new Guid("cc04b8ae-01cb-4233-8c82-73e77b21e980"), "PRD-3" }
                });

            migrationBuilder.InsertData(
                table: "ProductInventory",
                columns: new[] { "ProductInventoryId", "CanPurchase", "InventoryId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("b1abf910-c741-48b1-b04a-70268b4e45cf"), true, new Guid("7aa9115d-00d9-4215-98fa-cbd9aceb0744"), new Guid("15f110f6-38e8-4a21-a344-e5f164f233d6"), 10 },
                    { new Guid("bc05daab-f814-4871-9cfa-6e524a75c456"), true, new Guid("db9af98a-2a0e-4888-9cab-2b9d018bdf88"), new Guid("15f110f6-38e8-4a21-a344-e5f164f233d6"), 3 },
                    { new Guid("d6f271eb-94fd-4baf-a426-2a0700ddf053"), true, new Guid("db9af98a-2a0e-4888-9cab-2b9d018bdf88"), new Guid("3d7c9d9b-d889-40f0-963c-643f9ec28d0c"), 1 },
                    { new Guid("6c7e3fbe-c255-4f8e-884f-077516240d97"), true, new Guid("2bd3355c-e658-4973-9c30-008f85d103bb"), new Guid("3d7c9d9b-d889-40f0-963c-643f9ec28d0c"), 9 },
                    { new Guid("b6209206-0c3c-42f0-b3c2-8bf4e4e26478"), true, new Guid("7aa9115d-00d9-4215-98fa-cbd9aceb0744"), new Guid("cc04b8ae-01cb-4233-8c82-73e77b21e980"), 5 },
                    { new Guid("48493d82-dd28-4c9e-ac19-53d7b5bba198"), true, new Guid("2bd3355c-e658-4973-9c30-008f85d103bb"), new Guid("cc04b8ae-01cb-4233-8c82-73e77b21e980"), 8 }
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
