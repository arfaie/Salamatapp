using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class v42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "SurveyOfIinsureds",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "SurveyOfIinsureds");
        }
    }
}
