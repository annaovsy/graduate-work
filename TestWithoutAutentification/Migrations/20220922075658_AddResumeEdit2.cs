using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class AddResumeEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitizenshipId",
                table: "Resume",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationalInstitutionId",
                table: "Resume",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForeignLanguageId",
                table: "Resume",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceOfWorkId",
                table: "Resume",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenshipId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "EducationalInstitutionId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "ForeignLanguageId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "PlaceOfWorkId",
                table: "Resume");
        }
    }
}
