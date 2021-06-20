using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class FixRegistredClassAndPaidSession2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidSessions_AvailableClasses_AvailableClassClassId",
                table: "PaidSessions");

            migrationBuilder.DropIndex(
                name: "IX_PaidSessions_AvailableClassClassId",
                table: "PaidSessions");

            migrationBuilder.DropColumn(
                name: "AvailableClassClassId",
                table: "PaidSessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvailableClassClassId",
                table: "PaidSessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaidSessions_AvailableClassClassId",
                table: "PaidSessions",
                column: "AvailableClassClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidSessions_AvailableClasses_AvailableClassClassId",
                table: "PaidSessions",
                column: "AvailableClassClassId",
                principalTable: "AvailableClasses",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
