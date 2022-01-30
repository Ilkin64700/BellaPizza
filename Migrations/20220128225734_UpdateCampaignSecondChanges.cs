using Microsoft.EntityFrameworkCore.Migrations;

namespace BellaPizza.Migrations
{
    public partial class UpdateCampaignSecondChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "ChildrenParties");

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "Birthdays",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "Birthdays");

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "ChildrenParties",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
