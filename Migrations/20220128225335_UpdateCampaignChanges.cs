using Microsoft.EntityFrameworkCore.Migrations;

namespace BellaPizza.Migrations
{
    public partial class UpdateCampaignChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "MasterClasses");

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "ChildrenParties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "ChildrenParties");

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "MasterClasses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
