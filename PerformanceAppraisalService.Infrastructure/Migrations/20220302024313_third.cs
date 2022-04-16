using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Organizations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Organizations",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
