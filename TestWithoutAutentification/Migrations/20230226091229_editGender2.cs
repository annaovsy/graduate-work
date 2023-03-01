using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class editGender2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Sex_SexId",
                table: "Resume");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropIndex(
                name: "IX_Resume_SexId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "SexId",
                table: "Resume");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Resume",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resume_GenderId",
                table: "Resume",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Gender_GenderId",
                table: "Resume",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Gender_GenderId",
                table: "Resume");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_Resume_GenderId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Resume");

            migrationBuilder.AddColumn<int>(
                name: "SexId",
                table: "Resume",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resume_SexId",
                table: "Resume",
                column: "SexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Sex_SexId",
                table: "Resume",
                column: "SexId",
                principalTable: "Sex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
