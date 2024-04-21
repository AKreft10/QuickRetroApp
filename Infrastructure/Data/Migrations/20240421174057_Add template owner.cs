using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addtemplateowner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RetroBoardTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RetroBoardTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RetroBoardTemplates_UserId",
                table: "RetroBoardTemplates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetroBoardTemplates_Users_UserId",
                table: "RetroBoardTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetroBoardTemplates_Users_UserId",
                table: "RetroBoardTemplates");

            migrationBuilder.DropIndex(
                name: "IX_RetroBoardTemplates_UserId",
                table: "RetroBoardTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RetroBoardTemplates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RetroBoardTemplates");
        }
    }
}
