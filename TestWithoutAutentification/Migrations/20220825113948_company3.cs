using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class company3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameContactPerson",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameContactPerson",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);
        }
    }
}
