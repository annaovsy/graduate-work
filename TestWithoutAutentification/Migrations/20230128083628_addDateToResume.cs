using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWithoutAutentification.Migrations
{
    public partial class addDateToResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Resume",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Resume",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resume_SpecializationId",
                table: "Resume",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Specialization_SpecializationId",
                table: "Resume",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Specialization_SpecializationId",
                table: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_Resume_SpecializationId",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Resume");
        }
    }
}
