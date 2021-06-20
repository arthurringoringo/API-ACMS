using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class FixRegistredClassAndPaidSession6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidSessions_Student_StudentId",
                table: "PaidSessions");

            migrationBuilder.DropIndex(
                name: "IX_PaidSessions_StudentId",
                table: "PaidSessions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "PaidSessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "PaidSessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaidSessions_StudentId",
                table: "PaidSessions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidSessions_Student_StudentId",
                table: "PaidSessions",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
