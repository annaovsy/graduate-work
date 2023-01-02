using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class salaryReguriment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_Salary_SalaryId",
                table: "Vacancy");

            migrationBuilder.DropIndex(
                name: "IX_Vacancy_SalaryId",
                table: "Vacancy");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "Vacancy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_SalaryId",
                table: "Vacancy",
                column: "SalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_Salary_SalaryId",
                table: "Vacancy",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancy_Salary_SalaryId",
                table: "Vacancy");

            migrationBuilder.DropIndex(
                name: "IX_Vacancy_SalaryId",
                table: "Vacancy");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "Vacancy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_SalaryId",
                table: "Vacancy",
                column: "SalaryId",
                unique: true,
                filter: "[SalaryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancy_Salary_SalaryId",
                table: "Vacancy",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
