using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaceuticalsAPI.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UNQ_Attributes_AttributeName",
                table: "Attributes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
