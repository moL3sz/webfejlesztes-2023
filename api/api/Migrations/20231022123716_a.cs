using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId",
                table: "ProjectUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ResponsibleUserId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProjectUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId",
                table: "ProjectUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ResponsibleUserId",
                table: "Tickets",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId",
                table: "ProjectUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ResponsibleUserId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "Tickets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProjectUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_AspNetUsers_UserId",
                table: "ProjectUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ResponsibleUserId",
                table: "Tickets",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
