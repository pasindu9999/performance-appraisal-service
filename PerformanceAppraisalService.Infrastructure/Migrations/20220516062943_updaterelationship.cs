using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class updaterelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentHeadId",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                unique: true,
                filter: "[DepartmentHeadId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentHeadId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
