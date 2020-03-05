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
                values: new object[] { new Guid("43860c5d-4244-4c8e-b455-be8c58a67d95"), "Product-1" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9d90c1b8-623a-4d29-85b5-d24b9ec61d91"), "Product-2" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8300d0f7-c54c-420a-b9da-afb1213fef79"), "Product-3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
