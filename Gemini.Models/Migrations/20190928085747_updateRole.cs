using Microsoft.EntityFrameworkCore.Migrations;

namespace Gemini.Models.Migrations
{
    public partial class updateRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "REMARK",
                table: "sys_Roles",
                newName: "Remark");

            migrationBuilder.RenameColumn(
                name: "CREATE_TIME",
                table: "sys_Roles",
                newName: "CreateTime");

            migrationBuilder.AddColumn<int>(
                name: "Enabled",
                table: "sys_Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "sys_RoleMenus",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_RoleMenus", x => new { x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_sys_RoleMenus_sys_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "sys_Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sys_RoleMenus_sys_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "sys_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sys_RoleMenus_RoleId",
                table: "sys_RoleMenus",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_RoleMenus");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "sys_Roles");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "sys_Roles",
                newName: "REMARK");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "sys_Roles",
                newName: "CREATE_TIME");
        }
    }
}
