using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopSolution.Data.Migrations
{
    public partial class vend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_Categories_CategoryId",
                table: "ProductInCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropColumn(
                name: "ShipEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShipPhoneNumber",
                table: "Orders",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ShipName",
                table: "Orders",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "ShipAddress",
                table: "Orders",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetails",
                newName: "CatId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryTranslations",
                newName: "SortOrder");

            migrationBuilder.AddColumn<int>(
                name: "CoundCustomer",
                table: "ProductTranslations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeBed",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoundCustomer",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeBed",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CMND",
                table: "Orders",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "More",
                table: "Orders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityChild",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsShowOnHome",
                table: "CategoryTranslations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "CategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CategoryTranslations",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                columns: new[] { "OrderId", "CatId" });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id);
                });

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
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "SortOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "SortOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "SortOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "SortOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoundCustomer", "DateCreated", "TypeBed" },
                values: new object[] { 2, new DateTime(2022, 10, 30, 18, 31, 54, 764, DateTimeKind.Local).AddTicks(6595), "Giường đơn" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CatId",
                table: "OrderDetails",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_CategoryTranslations_CatId",
                table: "OrderDetails",
                column: "CatId",
                principalTable: "CategoryTranslations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_CategoryTranslations_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId",
                principalTable: "CategoryTranslations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_CategoryTranslations_CatId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_CategoryTranslations_CategoryId",
                table: "ProductInCategories");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CatId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CoundCustomer",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "TypeBed",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "CoundCustomer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeBed",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CMND",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "More",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "QuantityChild",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsShowOnHome",
                table: "CategoryTranslations");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "CategoryTranslations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CategoryTranslations");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Orders",
                newName: "ShipPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Orders",
                newName: "ShipName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Orders",
                newName: "ShipAddress");

            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "OrderDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "CategoryTranslations",
                newName: "CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "ShipEmail",
                table: "Orders",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsShowOnHome = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "37fd1c7e-8d85-4375-bd3f-49e05e4884e9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2c5adf8-c610-4388-9ef4-0c5ee53521eb", "AQAAAAEAACcQAAAAEM5W4ig7ZLu7IAktKOmfztVsluwsNuyJahpY+292T0amym6WRWUGph8oBP/mo7KSxw==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 9, 2, 22, 8, 8, 182, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_Categories_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
