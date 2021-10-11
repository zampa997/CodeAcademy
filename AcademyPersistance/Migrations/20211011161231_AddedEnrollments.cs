using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyEfPersistance.Migrations
{
    public partial class AddedEnrollments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseEditionId = table.Column<long>(type: "bigint", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    StudentEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentFeedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_CourseEditions_CourseEditionId",
                        column: x => x.CourseEditionId,
                        principalTable: "CourseEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Person_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseEditionId",
                table: "Enrollments",
                column: "CourseEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");
        }
    }
}
