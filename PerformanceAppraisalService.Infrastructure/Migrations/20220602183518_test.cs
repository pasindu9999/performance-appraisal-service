using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerformanceAppraisalService.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviewees_Panels_PanelId",
                table: "Reviewees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviewees",
                table: "Reviewees");

            migrationBuilder.RenameTable(
                name: "Reviewees",
                newName: "Reviwees");

            migrationBuilder.RenameIndex(
                name: "IX_Reviewees_PanelId",
                table: "Reviwees",
                newName: "IX_Reviwees_PanelId");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "Reviwers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Reviwers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "Reviwees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Reviwees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviwees",
                table: "Reviwees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviwers_EmployeeId",
                table: "Reviwers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviwees_EmployeeId",
                table: "Reviwees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwees_Employees_EmployeeId",
                table: "Reviwees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwees_Panels_PanelId",
                table: "Reviwees",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwers_Employees_EmployeeId",
                table: "Reviwers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviwees_Employees_EmployeeId",
                table: "Reviwees");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviwees_Panels_PanelId",
                table: "Reviwees");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviwers_Employees_EmployeeId",
                table: "Reviwers");

            migrationBuilder.DropIndex(
                name: "IX_Reviwers_EmployeeId",
                table: "Reviwers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviwees",
                table: "Reviwees");

            migrationBuilder.DropIndex(
                name: "IX_Reviwees_EmployeeId",
                table: "Reviwees");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "Reviwers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Reviwers");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "Reviwees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Reviwees");

            migrationBuilder.RenameTable(
                name: "Reviwees",
                newName: "Reviewees");

            migrationBuilder.RenameIndex(
                name: "IX_Reviwees_PanelId",
                table: "Reviewees",
                newName: "IX_Reviewees_PanelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviewees",
                table: "Reviewees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviewees_Panels_PanelId",
                table: "Reviewees",
                column: "PanelId",
                principalTable: "Panels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
