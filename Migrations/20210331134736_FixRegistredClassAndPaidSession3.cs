using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class FixRegistredClassAndPaidSession3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidSessions_RegistredClass",
                table: "PaidSessions");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidSessions_RegistredClass",
                table: "PaidSessions",
                column: "RegistredClassId",
                principalTable: "RegistredClass",
                principalColumn: "RegistredClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidSessions_RegistredClass",
                table: "PaidSessions");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidSessions_RegistredClass",
                table: "PaidSessions",
                column: "RegistredClassId",
                principalTable: "RegistredClass",
                principalColumn: "RegistredClassId");
        }
    }
}
