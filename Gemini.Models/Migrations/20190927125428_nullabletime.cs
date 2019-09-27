using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gemini.Models.Migrations
{
    public partial class nullabletime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "sys_Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "sys_Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "sys_Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditUser",
                table: "sys_Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "sys_Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "sys_Users");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "sys_Users");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "sys_Users");

            migrationBuilder.DropColumn(
                name: "EditUser",
                table: "sys_Users");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "sys_Users");
        }
    }
}
