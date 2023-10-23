﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ResponsibleUserId",
                table: "Tickets",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ResponsibleUserId",
                table: "Tickets",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
