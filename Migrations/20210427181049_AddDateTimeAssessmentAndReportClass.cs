using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class AddDateTimeAssessmentAndReportClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassReport_RegistredClass_RegistredClassesRegistredClassId",
                table: "ClassReport");

            migrationBuilder.DropIndex(
                name: "IX_ClassReport_RegistredClassesRegistredClassId",
                table: "ClassReport");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "RegistredClass");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "RegistredClass");

            migrationBuilder.DropColumn(
                name: "RegistredClassesRegistredClassId",
                table: "ClassReport");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssessmentDate",
                table: "RegistredClass",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ClassReportId",
                table: "RegistredClass",
                maxLength: 250,
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_ClassReportId",
                table: "RegistredClass",
                column: "ClassReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistredClass_ClassReport",
                table: "RegistredClass",
                column: "ClassReportId",
                principalTable: "ClassReport",
                principalColumn: "ClassReportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistredClass_ClassReport",
                table: "RegistredClass");

            migrationBuilder.DropIndex(
                name: "IX_RegistredClass_ClassReportId",
                table: "RegistredClass");

            migrationBuilder.DropColumn(
                name: "AssessmentDate",
                table: "RegistredClass");

            migrationBuilder.DropColumn(
                name: "ClassReportId",
                table: "RegistredClass");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "RegistredClass",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "RegistredClass",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RegistredClassesRegistredClassId",
                table: "ClassReport",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassReport_RegistredClassesRegistredClassId",
                table: "ClassReport",
                column: "RegistredClassesRegistredClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassReport_RegistredClass_RegistredClassesRegistredClassId",
                table: "ClassReport",
                column: "RegistredClassesRegistredClassId",
                principalTable: "RegistredClass",
                principalColumn: "RegistredClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
