using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_Projects_ProjectId",
                table: "TicketCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketPriorities_Projects_ProjectId",
                table: "TicketPriorities");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketCategories_CategoryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketPriorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatuses_StatusId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatuses_Projects_ProjectId",
                table: "TicketStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketStatuses",
                table: "TicketStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketPriorities",
                table: "TicketPriorities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCategories",
                table: "TicketCategories");

            migrationBuilder.RenameTable(
                name: "TicketStatuses",
                newName: "TicketStatus");

            migrationBuilder.RenameTable(
                name: "TicketPriorities",
                newName: "TicketPriority");

            migrationBuilder.RenameTable(
                name: "TicketCategories",
                newName: "TicketCategory");

            migrationBuilder.RenameIndex(
                name: "IX_TicketStatuses_ProjectId",
                table: "TicketStatus",
                newName: "IX_TicketStatus_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketPriorities_ProjectId",
                table: "TicketPriority",
                newName: "IX_TicketPriority_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCategories_ProjectId",
                table: "TicketCategory",
                newName: "IX_TicketCategory_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TicketStatus",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TicketPriority",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TicketCategory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketStatus",
                table: "TicketStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketPriority",
                table: "TicketPriority",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCategory",
                table: "TicketCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategory_Projects_ProjectId",
                table: "TicketCategory",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketPriority_Projects_ProjectId",
                table: "TicketPriority",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketCategory_CategoryId",
                table: "Tickets",
                column: "CategoryId",
                principalTable: "TicketCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketPriority_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "TicketPriority",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatus_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "TicketStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatus_Projects_ProjectId",
                table: "TicketStatus",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategory_Projects_ProjectId",
                table: "TicketCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketPriority_Projects_ProjectId",
                table: "TicketPriority");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketCategory_CategoryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketPriority_PriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketStatus_StatusId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatus_Projects_ProjectId",
                table: "TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketStatus",
                table: "TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketPriority",
                table: "TicketPriority");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCategory",
                table: "TicketCategory");

            migrationBuilder.RenameTable(
                name: "TicketStatus",
                newName: "TicketStatuses");

            migrationBuilder.RenameTable(
                name: "TicketPriority",
                newName: "TicketPriorities");

            migrationBuilder.RenameTable(
                name: "TicketCategory",
                newName: "TicketCategories");

            migrationBuilder.RenameIndex(
                name: "IX_TicketStatus_ProjectId",
                table: "TicketStatuses",
                newName: "IX_TicketStatuses_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketPriority_ProjectId",
                table: "TicketPriorities",
                newName: "IX_TicketPriorities_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCategory_ProjectId",
                table: "TicketCategories",
                newName: "IX_TicketCategories_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TicketStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TicketPriorities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TicketCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketStatuses",
                table: "TicketStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketPriorities",
                table: "TicketPriorities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCategories",
                table: "TicketCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategories_Projects_ProjectId",
                table: "TicketCategories",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketPriorities_Projects_ProjectId",
                table: "TicketPriorities",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketCategories_CategoryId",
                table: "Tickets",
                column: "CategoryId",
                principalTable: "TicketCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketPriorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "TicketPriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketStatuses_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "TicketStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatuses_Projects_ProjectId",
                table: "TicketStatuses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
