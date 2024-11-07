using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class InstractorStudentsFlouenAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstractorStudent");

            migrationBuilder.CreateTable(
                name: "InstractorStudents",
                columns: table => new
                {
                    InstractorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstractorStudents", x => new { x.InstractorId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_InstractorStudents_Instractors_InstractorId",
                        column: x => x.InstractorId,
                        principalTable: "Instractors",
                        principalColumn: "InstractorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstractorStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstractorStudents_StudentId",
                table: "InstractorStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstractorStudents");

            migrationBuilder.CreateTable(
                name: "InstractorStudent",
                columns: table => new
                {
                    InstractorsInstractorId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstractorStudent", x => new { x.InstractorsInstractorId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_InstractorStudent_Instractors_InstractorsInstractorId",
                        column: x => x.InstractorsInstractorId,
                        principalTable: "Instractors",
                        principalColumn: "InstractorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstractorStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstractorStudent_StudentsStudentId",
                table: "InstractorStudent",
                column: "StudentsStudentId");
        }
    }
}
