using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class VersionNumber_Alter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TicketStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VersionNumber",
                table: "TicketStatuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TicketPriorities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VersionNumber",
                table: "TicketPriorities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TicketCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VersionNumber",
                table: "TicketCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VersionNumber",
                table: "Projects",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<string>(type: "text", nullable: false),
                    CreatorUserName = table.Column<string>(type: "text", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatorUserId = table.Column<string>(type: "text", nullable: false),
                    UpdaterUserName = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Clone = table.Column<bool>(type: "boolean", nullable: false),
                    VersionNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatuses_ProjectId",
                table: "TicketStatuses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPriorities_ProjectId",
                table: "TicketPriorities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategories_ProjectId",
                table: "TicketCategories",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectId",
                table: "ProjectUsers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserId",
                table: "ProjectUsers",
                column: "UserId");

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
                name: "FK_TicketStatuses_Projects_ProjectId",
                table: "TicketStatuses",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_Projects_ProjectId",
                table: "TicketCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketPriorities_Projects_ProjectId",
                table: "TicketPriorities");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatuses_Projects_ProjectId",
                table: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatuses_ProjectId",
                table: "TicketStatuses");

            migrationBuilder.DropIndex(
                name: "IX_TicketPriorities_ProjectId",
                table: "TicketPriorities");

            migrationBuilder.DropIndex(
                name: "IX_TicketCategories_ProjectId",
                table: "TicketCategories");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TicketStatuses");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "TicketStatuses");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TicketPriorities");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "TicketPriorities");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TicketCategories");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "TicketCategories");

            migrationBuilder.DropColumn(
                name: "VersionNumber",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Clone = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<string>(type: "text", nullable: false),
                    CreatorUserName = table.Column<string>(type: "text", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdaterUserName = table.Column<string>(type: "text", nullable: false),
                    UpdatorUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjects",
                column: "UserId");
        }
    }
}
