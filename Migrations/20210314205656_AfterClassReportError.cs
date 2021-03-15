using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class AfterClassReportError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistredClass_ClassReport",
                table: "RegistredClass");

            migrationBuilder.DropIndex(
                name: "IX_RegistredClass_ClassReportId",
                table: "RegistredClass");

            migrationBuilder.DropColumn(
                name: "ClassReportId",
                table: "RegistredClass");

            migrationBuilder.AddColumn<Guid>(
                name: "RegistredClassesRegistredClassId",
                table: "ClassReport",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassReport_RegistredClass_RegistredClassesRegistredClassId",
                table: "ClassReport");

            migrationBuilder.DropIndex(
                name: "IX_ClassReport_RegistredClassesRegistredClassId",
                table: "ClassReport");

            migrationBuilder.DropColumn(
                name: "RegistredClassesRegistredClassId",
                table: "ClassReport");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassReportId",
                table: "RegistredClass",
                type: "uniqueidentifier",
                maxLength: 250,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_ClassReportId",
                table: "RegistredClass",
                column: "ClassReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistredClass_ClassReport",
                table: "RegistredClass",
                column: "ClassReportId",
                principalTable: "ClassReport",
                principalColumn: "ClassReportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
