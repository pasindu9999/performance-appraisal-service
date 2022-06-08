using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class relationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Reviwers_ReviweeId",
                table: "Results");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Reviwees_ReviweeId",
                table: "Results",
                column: "ReviweeId",
                principalTable: "Reviwees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Reviwees_ReviweeId",
                table: "Results");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Reviwers_ReviweeId",
                table: "Results",
                column: "ReviweeId",
                principalTable: "Reviwers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
