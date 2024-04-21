using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RetroBoardTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetroBoardTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetroBoardTemplateColumns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetroBoardTemplateColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetroBoardTemplateColumns_RetroBoardTemplates_TemplateIdId",
                        column: x => x.TemplateIdId,
                        principalTable: "RetroBoardTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetroBoardTemplateColumns_TemplateIdId",
                table: "RetroBoardTemplateColumns",
                column: "TemplateIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetroBoardTemplateColumns");

            migrationBuilder.DropTable(
                name: "RetroBoardTemplates");
        }
    }
}
