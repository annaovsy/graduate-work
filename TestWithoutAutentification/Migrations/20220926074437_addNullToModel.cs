using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class addNullToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_City_CityId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_EducationLevel_EducationLevelId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Salary_SalaryId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Sex_SexId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Users_UserId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_WorkExperience_WorkExperienceId",
                table: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Resume_SalaryId",
                table: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Resume_UserId",
                table: "Resume");

            migrationBuilder.AlterColumn<int>(
                name: "WorkExperienceId",
                table: "Resume",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Resume",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SexId",
                table: "Resume",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "Resume",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EducationLevelId",
                table: "Resume",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Resume",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_SalaryId",
                table: "Resume",
                column: "SalaryId",
                unique: true,
                filter: "[SalaryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_UserId",
                table: "Resume",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_City_CityId",
                table: "Resume",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_EducationLevel_EducationLevelId",
                table: "Resume",
                column: "EducationLevelId",
                principalTable: "EducationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Salary_SalaryId",
                table: "Resume",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Sex_SexId",
                table: "Resume",
                column: "SexId",
                principalTable: "Sex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Users_UserId",
                table: "Resume",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_WorkExperience_WorkExperienceId",
                table: "Resume",
                column: "WorkExperienceId",
                principalTable: "WorkExperience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_City_CityId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_EducationLevel_EducationLevelId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Salary_SalaryId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Sex_SexId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Users_UserId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_Resume_WorkExperience_WorkExperienceId",
                table: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Resume_SalaryId",
                table: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Resume_UserId",
                table: "Resume");

            migrationBuilder.AlterColumn<int>(
                name: "WorkExperienceId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SexId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EducationLevelId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resume_SalaryId",
                table: "Resume",
                column: "SalaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resume_UserId",
                table: "Resume",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_City_CityId",
                table: "Resume",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_EducationLevel_EducationLevelId",
                table: "Resume",
                column: "EducationLevelId",
                principalTable: "EducationLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Salary_SalaryId",
                table: "Resume",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Sex_SexId",
                table: "Resume",
                column: "SexId",
                principalTable: "Sex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Users_UserId",
                table: "Resume",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_WorkExperience_WorkExperienceId",
                table: "Resume",
                column: "WorkExperienceId",
                principalTable: "WorkExperience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
