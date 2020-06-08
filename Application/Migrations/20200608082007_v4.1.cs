using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class v41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_TblPersonal_PersonalId",
                table: "OfficeRefrandums");

            migrationBuilder.RenameColumn(
                name: "PersonalId",
                table: "OfficeRefrandums",
                newName: "idPerson");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeRefrandums_PersonalId",
                table: "OfficeRefrandums",
                newName: "IX_OfficeRefrandums_idPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_TblPersonal_idPerson",
                table: "OfficeRefrandums",
                column: "idPerson",
                principalTable: "TblPersonal",
                principalColumn: "idPerson",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_TblPersonal_idPerson",
                table: "OfficeRefrandums");

            migrationBuilder.RenameColumn(
                name: "idPerson",
                table: "OfficeRefrandums",
                newName: "PersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_OfficeRefrandums_idPerson",
                table: "OfficeRefrandums",
                newName: "IX_OfficeRefrandums_PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_TblPersonal_PersonalId",
                table: "OfficeRefrandums",
                column: "PersonalId",
                principalTable: "TblPersonal",
                principalColumn: "idPerson",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
