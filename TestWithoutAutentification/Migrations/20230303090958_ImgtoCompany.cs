using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class ImgtoCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_Images_ImageId",
                table: "Vacancy");

            migrationBuilder.DropIndex(
                name: "IX_Vacancy_ImageId",
                table: "Vacancy");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Vacancy");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ImageId",
                table: "Companies",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Images_ImageId",
                table: "Companies",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Images_ImageId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ImageId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Vacancy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_ImageId",
                table: "Vacancy",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_Images_ImageId",
                table: "Vacancy",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
