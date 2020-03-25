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
                    { new Guid("8481c547-5c86-4ab0-9b1d-feca5f83dc50"), "Inventory-1-Location", "Inventory-1" },
                    { new Guid("3cc932b6-30e2-49ae-81be-8e60fbd2d099"), "Inventory-2-Location", "Inventory-2" },
                    { new Guid("6312e285-4ddf-49f1-bb48-748cf0007f8f"), "Inventory-3-Location", "Inventory-3" }
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
                columns: new[] { "ProductInventoryId", "CanPurchase", "InventoryId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("82165589-744e-46fe-9262-3fd9c4d150d8"), true, new Guid("8481c547-5c86-4ab0-9b1d-feca5f83dc50"), new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), 10 },
                    { new Guid("e7404688-e264-4276-9053-a83650637dc6"), true, new Guid("3cc932b6-30e2-49ae-81be-8e60fbd2d099"), new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), 3 },
                    { new Guid("f7d9408b-adf3-4b92-ae9a-f08f1fa50f11"), true, new Guid("3cc932b6-30e2-49ae-81be-8e60fbd2d099"), new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), 1 },
                    { new Guid("17ff10f9-8bb3-4467-8265-f1018c7c4748"), true, new Guid("6312e285-4ddf-49f1-bb48-748cf0007f8f"), new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), 9 },
                    { new Guid("54da83c1-978f-4486-906a-04a292513c43"), true, new Guid("8481c547-5c86-4ab0-9b1d-feca5f83dc50"), new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), 5 },
                    { new Guid("4ae132f8-c42f-4d2a-be63-68f3346e51a3"), true, new Guid("6312e285-4ddf-49f1-bb48-748cf0007f8f"), new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), 8 }
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
