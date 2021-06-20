using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class AddlastNameTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teacher",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teacher");
        }
    }
}
