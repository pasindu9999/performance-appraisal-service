using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class te : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviwees_Panels_PanelId",
                table: "Reviwees");

            migrationBuilder.AlterColumn<Guid>(
                name: "PanelId",
                table: "Reviwees",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwees_Panels_PanelId",
                table: "Reviwees",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviwees_Panels_PanelId",
                table: "Reviwees");

            migrationBuilder.AlterColumn<Guid>(
                name: "PanelId",
                table: "Reviwees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwees_Panels_PanelId",
                table: "Reviwees",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
