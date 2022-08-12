using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ticket.Migrations
{
    public partial class NewMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeIdUserType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTypeIdUserType",
                table: "Users",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeIdUserType",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "IdUserType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "Users",
                newName: "UserTypeIdUserType");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserTypeIdUserType");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeIdUserType",
                table: "Users",
                column: "UserTypeIdUserType",
                principalTable: "UserTypes",
                principalColumn: "IdUserType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
