using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetroBoardTemplateColumns_RetroBoardTemplates_TemplateIdId",
                table: "RetroBoardTemplateColumns");

            migrationBuilder.RenameColumn(
                name: "TemplateIdId",
                table: "RetroBoardTemplateColumns",
                newName: "TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_RetroBoardTemplateColumns_TemplateIdId",
                table: "RetroBoardTemplateColumns",
                newName: "IX_RetroBoardTemplateColumns_TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetroBoardTemplateColumns_RetroBoardTemplates_TemplateId",
                table: "RetroBoardTemplateColumns",
                column: "TemplateId",
                principalTable: "RetroBoardTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetroBoardTemplateColumns_RetroBoardTemplates_TemplateId",
                table: "RetroBoardTemplateColumns");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "RetroBoardTemplateColumns",
                newName: "TemplateIdId");

            migrationBuilder.RenameIndex(
                name: "IX_RetroBoardTemplateColumns_TemplateId",
                table: "RetroBoardTemplateColumns",
                newName: "IX_RetroBoardTemplateColumns_TemplateIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetroBoardTemplateColumns_RetroBoardTemplates_TemplateIdId",
                table: "RetroBoardTemplateColumns",
                column: "TemplateIdId",
                principalTable: "RetroBoardTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
