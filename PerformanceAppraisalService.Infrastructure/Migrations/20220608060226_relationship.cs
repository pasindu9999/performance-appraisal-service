using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Reviwers_ReviwerId",
                table: "Results");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviwerId",
                table: "Results",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Reviwers_ReviwerId",
                table: "Results",
                column: "ReviwerId",
                principalTable: "Reviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Reviwers_ReviwerId",
                table: "Results");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviwerId",
                table: "Results",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Reviwers_ReviwerId",
                table: "Results",
                column: "ReviwerId",
                principalTable: "Reviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
