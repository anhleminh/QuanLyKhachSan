using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    public partial class vend2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductInDanhMuc",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DanhMucId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInDanhMuc", x => new { x.DanhMucId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInDanhMuc_DanhMuc_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInDanhMuc_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "10db353b-5d41-4f6e-815e-d643b1a2c2f8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4ac1f61-ee80-4264-aae0-7af8a74225a9", "AQAAAAEAACcQAAAAEFhi4F9EdV2HHtGgJa9J5zipi7vpNZNmUCjl51z/o50katZC/pLFkYxLR4m3iO2WHg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 10, 30, 21, 5, 2, 888, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.CreateIndex(
                name: "IX_ProductInDanhMuc_ProductId",
                table: "ProductInDanhMuc",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInDanhMuc");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9c83d6ba-a32a-4611-a8f9-4c1b1fab9d0e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f638d4f-a08f-49e3-aaa7-753f70aa08dc", "AQAAAAEAACcQAAAAEL6/qbsrQeO7/rzM29/o7A9OhYuIyGtlVZWJgZTeHXmvd4QFxQiDv0ocUrpyVu715g==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 10, 30, 18, 31, 54, 764, DateTimeKind.Local).AddTicks(6595));
        }
    }
}
