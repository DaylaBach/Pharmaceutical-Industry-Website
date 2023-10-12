using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaceuticalsAPI.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsAttributeValues");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Attributes");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Managers",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Attributes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Attributes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Attributes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_ProductId",
                table: "Attributes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Products_ProductId",
                table: "Attributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Products_ProductId",
                table: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_ProductId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Attributes");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Managers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Attributes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    AttributeValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.AttributeValueId);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsAttributeValues",
                columns: table => new
                {
                    ProductAttributeValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeValueId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsAttributeValues", x => x.ProductAttributeValueId);
                    table.ForeignKey(
                        name: "FK_ProductsAttributeValues_AttributeValues_AttributeValueId",
                        column: x => x.AttributeValueId,
                        principalTable: "AttributeValues",
                        principalColumn: "AttributeValueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsAttributeValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsAttributeValues_AttributeValueId",
                table: "ProductsAttributeValues",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsAttributeValues_ProductId",
                table: "ProductsAttributeValues",
                column: "ProductId");
        }
    }
}
