using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_tbl_Education_IdEdu",
                table: "OfficeRefrandums");

            migrationBuilder.RenameColumn(
                name: "YearsOfService",
                table: "OfficeRefrandums",
                newName: "YearsOfServiceId");

            migrationBuilder.RenameColumn(
                name: "IdEdu",
                table: "OfficeRefrandums",
                newName: "IdEduu");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeRefrandums_IdEdu",
                table: "OfficeRefrandums",
                newName: "IX_OfficeRefrandums_IdEduu");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_YearsOfServiceId",
                table: "OfficeRefrandums",
                column: "YearsOfServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_TblEducation2_IdEduu",
                table: "OfficeRefrandums",
                column: "IdEduu",
                principalTable: "TblEducation2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_TblLongOfServices_YearsOfServiceId",
                table: "OfficeRefrandums",
                column: "YearsOfServiceId",
                principalTable: "TblLongOfServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_TblEducation2_IdEduu",
                table: "OfficeRefrandums");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_TblLongOfServices_YearsOfServiceId",
                table: "OfficeRefrandums");

            migrationBuilder.DropIndex(
                name: "IX_OfficeRefrandums_YearsOfServiceId",
                table: "OfficeRefrandums");

            migrationBuilder.RenameColumn(
                name: "YearsOfServiceId",
                table: "OfficeRefrandums",
                newName: "YearsOfService");

            migrationBuilder.RenameColumn(
                name: "IdEduu",
                table: "OfficeRefrandums",
                newName: "IdEdu");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeRefrandums_IdEduu",
                table: "OfficeRefrandums",
                newName: "IX_OfficeRefrandums_IdEdu");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_tbl_Education_IdEdu",
                table: "OfficeRefrandums",
                column: "IdEdu",
                principalTable: "tbl_Education",
                principalColumn: "idEdu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
