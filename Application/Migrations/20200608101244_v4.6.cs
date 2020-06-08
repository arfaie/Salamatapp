using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class v46 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "OfficeRefrandums",
                newName: "SubmitDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmitDateTime",
                table: "OfficeRefrandums",
                newName: "DateTime");
        }
    }
}
