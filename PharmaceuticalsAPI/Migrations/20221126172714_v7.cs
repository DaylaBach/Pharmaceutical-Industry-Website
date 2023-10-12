using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PharmaceuticalsAPI.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Image = table.Column<string>(maxLength: 512, nullable: true),
                    Resume = table.Column<string>(nullable: false),
                    Education = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Created_date = table.Column<DateTime>(nullable: false, defaultValue: DateTime.Now)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.AddUniqueConstraint(
                name: "UNQ_Managers_Username",
                table: "Managers",
                column: "Username",
                schema: default
                );

            migrationBuilder.AddUniqueConstraint(
                name: "UNQ_Managers_Email",
                table: "Managers",
                column: "Email",
                schema: default
                );

            migrationBuilder.AddUniqueConstraint(
                name: "UNQ_Candidates_Email",
                table: "Candidates",
                column: "Email",
                schema: default
                );

            migrationBuilder.Sql("INSERT into Managers(AdminId,FullName, Email, Username, [Password]) Values " +
                "('"+ Guid.NewGuid().ToString() +"','Full Name','EmailAddress@gmail.com','admin','123456')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
