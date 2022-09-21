using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class addCompanyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstNameContactPerson",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LastNameContactPerson",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "NameContactPerson",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FirstNameContactPerson",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastNameContactPerson",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "NameContactPerson",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companies");
        }
    }
}
