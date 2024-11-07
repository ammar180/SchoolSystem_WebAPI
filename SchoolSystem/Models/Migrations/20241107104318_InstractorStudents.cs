using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class InstractorStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instractors_InstractorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_InstractorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InstractorId",
                table: "Students");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstractorStudent");

            migrationBuilder.AddColumn<int>(
                name: "InstractorId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_InstractorId",
                table: "Students",
                column: "InstractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instractors_InstractorId",
                table: "Students",
                column: "InstractorId",
                principalTable: "Instractors",
                principalColumn: "InstractorId");
        }
    }
}
