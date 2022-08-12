using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ticket.Migrations
{
    public partial class NewMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_PriorityIdPriority",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Statuses_StatusIdStatus",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StatusIdStatus",
                table: "Tickets",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "PriorityIdPriority",
                table: "Tickets",
                newName: "PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_StatusIdStatus",
                table: "Tickets",
                newName: "IX_Tickets_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PriorityIdPriority",
                table: "Tickets",
                newName: "IX_Tickets_PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "IdPriority",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Statuses_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Statuses_StatusId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Tickets",
                newName: "StatusIdStatus");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Tickets",
                newName: "PriorityIdPriority");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                newName: "IX_Tickets_StatusIdStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets",
                newName: "IX_Tickets_PriorityIdPriority");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_PriorityIdPriority",
                table: "Tickets",
                column: "PriorityIdPriority",
                principalTable: "Priorities",
                principalColumn: "IdPriority",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Statuses_StatusIdStatus",
                table: "Tickets",
                column: "StatusIdStatus",
                principalTable: "Statuses",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
