using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Migrations
{
    public partial class Add_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("075fd9eb-c9f2-4822-ad94-0cf95607ecd7"), "Product-1" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("bb44b328-3506-445c-9db8-4a7f6ebfb0a5"), "Product-2" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("116333c2-b017-40b8-a442-697bdc70e1d9"), "Product-3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
