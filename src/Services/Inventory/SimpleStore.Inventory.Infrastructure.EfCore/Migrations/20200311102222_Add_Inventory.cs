using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.Inventory.Infrastructure.EfCore.Migrations
{
    public partial class Add_Inventory : Migration
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

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { new Guid("0ecf66a2-7fc0-48ba-8d24-5a567c7ea8ee"), "Inventory-1-Location", "Inventory-1" });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { new Guid("1e4330ff-fe3a-4fbb-8878-8cecf04dd31f"), "Inventory-2-Location", "Inventory-2" });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { new Guid("ad6a188d-db6d-4f47-a103-e3d12ee6cc36"), "Inventory-3-Location", "Inventory-3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
