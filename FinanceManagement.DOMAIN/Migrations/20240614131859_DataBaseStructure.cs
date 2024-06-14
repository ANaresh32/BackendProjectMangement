using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagement.DOMAIN.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientLocation = table.Column<string>(type: "text", nullable: true),
                    ReferenceName = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjectsList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<string>(type: "text", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    Projectid = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectBasePrice = table.Column<int>(type: "integer", nullable: false),
                    ProjectType = table.Column<string>(type: "text", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjectsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjectsList_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProjectsList_Projects_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<string>(type: "text", nullable: true),
                    EmployeeId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    Projectid = table.Column<Guid>(type: "uuid", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoursWorked = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeSheets_Projects_Projectid",
                        column: x => x.Projectid,
                        principalTable: "Projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjectsList_EmployeeId1",
                table: "EmployeeProjectsList",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjectsList_Projectid",
                table: "EmployeeProjectsList",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeId1",
                table: "TimeSheets",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_Projectid",
                table: "TimeSheets",
                column: "Projectid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "EmployeeProjectsList");

            migrationBuilder.DropTable(
                name: "TimeSheets");
        }
    }
}
