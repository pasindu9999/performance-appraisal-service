using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PA_lists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Employee_Name = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Dep_Head_Name = table.Column<string>(nullable: true),
                    Due_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PA_lists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PA_lists");
        }
    }
}
