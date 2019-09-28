using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gemini.Models.Migrations
{
    public partial class menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuName = table.Column<string>(nullable: true),
                    MenuIndex = table.Column<string>(nullable: true),
                    MenuUrl = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ICON = table.Column<string>(nullable: true),
                    Enabled = table.Column<int>(nullable: false),
                    SortCode = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    REMARK = table.Column<string>(nullable: true),
                    CREATE_TIME = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sys_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_sys_UserRoles_sys_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "sys_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_UserRoles_sys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "sys_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sys_UserRoles_RoleId",
                table: "sys_UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_Menus");

            migrationBuilder.DropTable(
                name: "sys_UserRoles");

            migrationBuilder.DropTable(
                name: "sys_Roles");
        }
    }
}
