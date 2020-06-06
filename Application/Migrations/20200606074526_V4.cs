using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeTypeId",
                table: "OfficeRefrandums");

            migrationBuilder.RenameColumn(
                name: "EmployeeTypeId",
                table: "OfficeRefrandums",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeRefrandums_EmployeeTypeId",
                table: "OfficeRefrandums",
                newName: "IX_OfficeRefrandums_EmployeeId");

            migrationBuilder.CreateTable(
                name: "TblEducation2",
                columns: table => new
                {
                    idEdu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EduName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEducation2", x => x.idEdu);
                });

            migrationBuilder.CreateTable(
                name: "TblYearsOfServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblYearsOfServices", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeId",
                table: "OfficeRefrandums",
                column: "EmployeeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeId",
                table: "OfficeRefrandums");

            migrationBuilder.DropTable(
                name: "TblEducation2");

            migrationBuilder.DropTable(
                name: "TblYearsOfServices");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "OfficeRefrandums",
                newName: "EmployeeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeRefrandums_EmployeeId",
                table: "OfficeRefrandums",
                newName: "IX_OfficeRefrandums_EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeTypeId",
                table: "OfficeRefrandums",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
