using Microsoft.EntityFrameworkCore.Migrations;

namespace BellaPizza.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Summ",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Summ",
                table: "Orders",
                type: "int",
                nullable: false,
                computedColumnSql: "[Quamtity] * [Price]");
        }
    }
}
