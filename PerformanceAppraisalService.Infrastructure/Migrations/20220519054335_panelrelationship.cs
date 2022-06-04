using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class panelrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviweeID",
                table: "Panels");

            migrationBuilder.DropColumn(
                name: "ReviwerID",
                table: "Panels");

            migrationBuilder.CreateTable(
                name: "Reviewees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PanelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviewees_Panels_PanelId",
                        column: x => x.PanelId,
                        principalTable: "Panels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviwers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviwers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PanelReviwer",
                columns: table => new
                {
                    PanelId = table.Column<Guid>(nullable: false),
                    ReviwerId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelReviwer", x => new { x.PanelId, x.ReviwerId });
                    table.ForeignKey(
                        name: "FK_PanelReviwer_Panels_PanelId",
                        column: x => x.PanelId,
                        principalTable: "Panels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PanelReviwer_Reviwers_ReviwerId",
                        column: x => x.ReviwerId,
                        principalTable: "Reviwers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanelReviwer_ReviwerId",
                table: "PanelReviwer",
                column: "ReviwerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviewees_PanelId",
                table: "Reviewees",
                column: "PanelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanelReviwer");

            migrationBuilder.DropTable(
                name: "Reviewees");

            migrationBuilder.DropTable(
                name: "Reviwers");

            migrationBuilder.AddColumn<int>(
                name: "ReviweeID",
                table: "Panels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviwerID",
                table: "Panels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PanelID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviweeDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviweeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviweeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });
        }
    }
}
