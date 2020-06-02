using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class Ref_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeId",
                table: "OfficeRefrandums");

            migrationBuilder.DropIndex(
                name: "IX_OfficeRefrandums_EmployeeId",
                table: "OfficeRefrandums");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "OfficeRefrandums");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_EmployeeTypeId",
                table: "OfficeRefrandums",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeTypeId",
                table: "OfficeRefrandums",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeTypeId",
                table: "OfficeRefrandums");

            migrationBuilder.DropIndex(
                name: "IX_OfficeRefrandums_EmployeeTypeId",
                table: "OfficeRefrandums");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "OfficeRefrandums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_EmployeeId",
                table: "OfficeRefrandums",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeId",
                table: "OfficeRefrandums",
                column: "EmployeeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
