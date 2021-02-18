using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIACMS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassCategory",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    IncomeInstructor = table.Column<decimal>(type: "smallmoney", nullable: true),
                    IncomeAIU = table.Column<decimal>(type: "smallmoney", nullable: true),
                    TotalTutionFee = table.Column<decimal>(type: "smallmoney", nullable: true),
                    DiscountedFee = table.Column<decimal>(type: "smallmoney", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ClassReport",
                columns: table => new
                {
                    ClassReportId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassReport", x => x.ClassReportId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    MethodName = table.Column<string>(maxLength: 250, nullable: true),
                    Terms = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    Sex = table.Column<string>(maxLength: 1, nullable: true),
                    ParentGuardianName = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(maxLength: 450, nullable: true),
                    HomeNumber = table.Column<string>(maxLength: 50, nullable: true),
                    SchoolName = table.Column<string>(maxLength: 250, nullable: true),
                    UserId = table.Column<int>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    Sex = table.Column<string>(maxLength: 1, nullable: true),
                    Address = table.Column<string>(maxLength: 450, nullable: true),
                    HomeNumber = table.Column<string>(maxLength: 250, nullable: true),
                    UserId = table.Column<int>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teacher_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableClasses",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    ClassName = table.Column<string>(maxLength: 250, nullable: true),
                    TeacherId = table.Column<Guid>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableClasses", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_AvailableClasses_Teacher",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaidSessions",
                columns: table => new
                {
                    PaidSessionId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(maxLength: 250, nullable: false),
                    ClassId = table.Column<Guid>(maxLength: 250, nullable: false),
                    DatePaid = table.Column<DateTime>(type: "datetime", nullable: true),
                    PictureLink = table.Column<string>(nullable: true),
                    PaymentAccepted = table.Column<bool>(nullable: true),
                    PaymentsMonth = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidSessions", x => x.PaidSessionId);
                    table.ForeignKey(
                        name: "FK_PaidSessions_AvailableClasses",
                        column: x => x.ClassId,
                        principalTable: "AvailableClasses",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaidSessions_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "RegistredClass",
                columns: table => new
                {
                    RegistredClassId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CategoryId = table.Column<Guid>(maxLength: 250, nullable: false),
                    ClassId = table.Column<Guid>(maxLength: 250, nullable: false),
                    ConfirmedByTeacher = table.Column<bool>(nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime", nullable: false),
                    Day = table.Column<string>(maxLength: 50, nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    PaymentMethodId = table.Column<Guid>(maxLength: 250, nullable: false),
                    FullyPaid = table.Column<bool>(nullable: true),
                    ClassReportId = table.Column<Guid>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistredClass", x => x.RegistredClassId);
                    table.ForeignKey(
                        name: "FK_RegistredClass_ClassCategory",
                        column: x => x.CategoryId,
                        principalTable: "ClassCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistredClass_AvailableClasses",
                        column: x => x.ClassId,
                        principalTable: "AvailableClasses",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistredClass_ClassReport",
                        column: x => x.ClassReportId,
                        principalTable: "ClassReport",
                        principalColumn: "ClassReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistredClass_PaymentMethod",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistredClass_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "SessionSchedule",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<Guid>(maxLength: 250, nullable: false),
                    ClassId = table.Column<Guid>(maxLength: 250, nullable: false),
                    StudentId = table.Column<Guid>(maxLength: 250, nullable: false),
                    Time = table.Column<TimeSpan>(nullable: true),
                    Day = table.Column<string>(maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSchedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_SessionSchedule_AvailableClasses",
                        column: x => x.ClassId,
                        principalTable: "AvailableClasses",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionSchedule_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSchedule_Teacher",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableClasses_TeacherId",
                table: "AvailableClasses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_PaidSessions_ClassId",
                table: "PaidSessions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PaidSessions_StudentId",
                table: "PaidSessions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_CategoryId",
                table: "RegistredClass",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_ClassId",
                table: "RegistredClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_ClassReportId",
                table: "RegistredClass",
                column: "ClassReportId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_PaymentMethodId",
                table: "RegistredClass",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistredClass_StudentId",
                table: "RegistredClass",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSchedule_ClassId",
                table: "SessionSchedule",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSchedule_StudentId",
                table: "SessionSchedule",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSchedule_TeacherId",
                table: "SessionSchedule",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserId",
                table: "Teacher",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserClaim");

            migrationBuilder.DropTable(
                name: "PaidSessions");

            migrationBuilder.DropTable(
                name: "RegistredClass");

            migrationBuilder.DropTable(
                name: "SessionSchedule");

            migrationBuilder.DropTable(
                name: "ClassCategory");

            migrationBuilder.DropTable(
                name: "ClassReport");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "AvailableClasses");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
