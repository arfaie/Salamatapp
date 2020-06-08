using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class v43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NatCode",
                table: "OfficeRefrandums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NatCode",
                table: "OfficeRefrandums",
                nullable: true);
        }
    }
}
