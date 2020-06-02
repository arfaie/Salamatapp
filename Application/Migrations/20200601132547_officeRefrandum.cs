using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class officeRefrandum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeRefrandums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<bool>(nullable: false),
                    isMarried = table.Column<bool>(nullable: false),
                    YearsOfService = table.Column<int>(nullable: false),
                    IdEdu = table.Column<int>(nullable: false),
                    EmployeeTypeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    IdQ1 = table.Column<string>(nullable: true),
                    IdQ2 = table.Column<string>(nullable: true),
                    IdQ3 = table.Column<string>(nullable: true),
                    IdQ4 = table.Column<string>(nullable: true),
                    IdQ5 = table.Column<string>(nullable: true),
                    IdQ6 = table.Column<string>(nullable: true),
                    IdQ7 = table.Column<string>(nullable: true),
                    IdQ8 = table.Column<string>(nullable: true),
                    IdQ9 = table.Column<string>(nullable: true),
                    IdQ10 = table.Column<string>(nullable: true),
                    IdQ11 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeRefrandums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeRefrandums_EmployeeTypes_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeRefrandums_tbl_Education_IdEdu",
                        column: x => x.IdEdu,
                        principalTable: "tbl_Education",
                        principalColumn: "idEdu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_EmployeeId",
                table: "OfficeRefrandums",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeRefrandums_IdEdu",
                table: "OfficeRefrandums",
                column: "IdEdu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeRefrandums");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");
        }
    }
}
