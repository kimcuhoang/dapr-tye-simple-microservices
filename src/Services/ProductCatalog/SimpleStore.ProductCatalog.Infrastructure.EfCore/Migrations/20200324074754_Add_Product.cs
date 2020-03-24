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
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4a2abe51-e895-49be-878a-0729535ba92e"), "PRD-1", "Product-1" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1d250f1d-1546-47f3-92d2-31fbf87a3511"), "PRD-2", "Product-2" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4012d62c-2bea-42eb-9e64-d7b22185c4f0"), "PRD-3", "Product-3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
