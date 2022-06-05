using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelReviwer_Panels_PanelId",
                table: "PanelReviwer");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelReviwer_Reviwers_ReviwerId",
                table: "PanelReviwer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PanelReviwer",
                table: "PanelReviwer");

            migrationBuilder.RenameTable(
                name: "PanelReviwer",
                newName: "PanelReviwers");

            migrationBuilder.RenameIndex(
                name: "IX_PanelReviwer_ReviwerId",
                table: "PanelReviwers",
                newName: "IX_PanelReviwers_ReviwerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "PanelReviwers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PanelReviwers",
                table: "PanelReviwers",
                columns: new[] { "PanelId", "ReviwerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PanelReviwers_Panels_PanelId",
                table: "PanelReviwers",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelReviwers_Reviwers_ReviwerId",
                table: "PanelReviwers",
                column: "ReviwerId",
                principalTable: "Reviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelReviwers_Panels_PanelId",
                table: "PanelReviwers");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelReviwers_Reviwers_ReviwerId",
                table: "PanelReviwers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PanelReviwers",
                table: "PanelReviwers");

            migrationBuilder.RenameTable(
                name: "PanelReviwers",
                newName: "PanelReviwer");

            migrationBuilder.RenameIndex(
                name: "IX_PanelReviwers_ReviwerId",
                table: "PanelReviwer",
                newName: "IX_PanelReviwer_ReviwerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "PanelReviwer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PanelReviwer",
                table: "PanelReviwer",
                columns: new[] { "PanelId", "ReviwerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PanelReviwer_Panels_PanelId",
                table: "PanelReviwer",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelReviwer_Reviwers_ReviwerId",
                table: "PanelReviwer",
                column: "ReviwerId",
                principalTable: "Reviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
