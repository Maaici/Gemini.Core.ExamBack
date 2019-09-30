using Microsoft.EntityFrameworkCore.Migrations;

namespace Gemini.Models.Migrations
{
    public partial class addEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Enabled",
                table: "sys_Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "sys_Users");
        }
    }
}
