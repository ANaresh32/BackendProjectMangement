using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.DOMAIN.Migrations
{
    /// <inheritdoc />
    public partial class ChangedGUIDinProjecttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RolesRoleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectManager",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RolesRoleId",
                table: "Employees",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RolesRoleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectManager",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RolesRoleId",
                table: "Employees",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");
        }
    }
}
