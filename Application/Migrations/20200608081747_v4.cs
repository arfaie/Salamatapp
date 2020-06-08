using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "OfficeRefrandums",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Des",
                table: "OfficeRefrandums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatCode",
                table: "OfficeRefrandums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "OfficeRefrandums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_PersonalId",
                table: "OfficeRefrandums",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeRefrandums_TblPersonal_PersonalId",
                table: "OfficeRefrandums",
                column: "PersonalId",
                principalTable: "TblPersonal",
                principalColumn: "idPerson",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeRefrandums_TblPersonal_PersonalId",
                table: "OfficeRefrandums");

            migrationBuilder.DropIndex(
                name: "IX_OfficeRefrandums_PersonalId",
                table: "OfficeRefrandums");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "OfficeRefrandums");

            migrationBuilder.DropColumn(
                name: "Des",
                table: "OfficeRefrandums");

            migrationBuilder.DropColumn(
                name: "NatCode",
                table: "OfficeRefrandums");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "OfficeRefrandums");
        }
    }
}
