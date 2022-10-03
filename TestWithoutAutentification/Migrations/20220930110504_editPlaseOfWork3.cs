using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class editPlaseOfWork3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfWork_Resume_ResumeId",
                table: "PlaceOfWork");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "PlaceOfWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceOfWork_Resume_ResumeId",
                table: "PlaceOfWork",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceOfWork_Resume_ResumeId",
                table: "PlaceOfWork");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "PlaceOfWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceOfWork_Resume_ResumeId",
                table: "PlaceOfWork",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
