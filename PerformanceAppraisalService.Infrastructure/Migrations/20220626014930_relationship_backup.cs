using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class relationship_backup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviwers_EmployeeId",
                table: "Reviwers");

            migrationBuilder.DropIndex(
                name: "IX_Reviwees_EmployeeId",
                table: "Reviwees");

            migrationBuilder.DropColumn(
                name: "IsDepartmentHead",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Certificateurl",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imageurl",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentHeadId",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfEmployees",
                table: "Departments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviwers_EmployeeId",
                table: "Reviwers",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviwees_EmployeeId",
                table: "Reviwees",
                column: "EmployeeId",
                unique: true);

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
                name: "IX_Reviwers_EmployeeId",
                table: "Reviwers");

            migrationBuilder.DropIndex(
                name: "IX_Reviwees_EmployeeId",
                table: "Reviwees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Certificateurl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Imageurl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "NoOfEmployees",
                table: "Departments");

            migrationBuilder.AddColumn<bool>(
                name: "IsDepartmentHead",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reviwers_EmployeeId",
                table: "Reviwers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviwees_EmployeeId",
                table: "Reviwees",
                column: "EmployeeId");
        }
    }
}
