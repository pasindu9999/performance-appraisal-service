using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PanelId",
                table: "PAsheets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAsheets_PanelId",
                table: "PAsheets",
                column: "PanelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PAsheets_Panels_PanelId",
                table: "PAsheets",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAsheets_Panels_PanelId",
                table: "PAsheets");

            migrationBuilder.DropIndex(
                name: "IX_PAsheets_PanelId",
                table: "PAsheets");

            migrationBuilder.DropColumn(
                name: "PanelId",
                table: "PAsheets");
        }
    }
}
