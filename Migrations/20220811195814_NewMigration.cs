using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ticket.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeIdUserType",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                table: "UserType");

            migrationBuilder.RenameTable(
                name: "UserType",
                newName: "UserTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "IdUserType");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeIdUserType",
                table: "Users",
                column: "UserTypeIdUserType",
                principalTable: "UserTypes",
                principalColumn: "IdUserType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeIdUserType",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "UserType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                table: "UserType",
                column: "IdUserType");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeIdUserType",
                table: "Users",
                column: "UserTypeIdUserType",
                principalTable: "UserType",
                principalColumn: "IdUserType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
