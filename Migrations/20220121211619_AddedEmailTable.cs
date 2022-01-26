using Microsoft.EntityFrameworkCore.Migrations;

namespace BellaPizza.Migrations
{
    public partial class AddedEmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "AppDetails");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "AppDetails",
                maxLength: 190,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AppDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "AppDetails",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "AppDetails",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "AppDetails",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "AppDetails");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AppDetails");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "AppDetails");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "AppDetails");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "AppDetails");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "AppDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
