using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class DealWithInstractorStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InstractorStudents",
                table: "InstractorStudents");

            migrationBuilder.DropIndex(
                name: "IX_InstractorStudents_StudentId",
                table: "InstractorStudents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstractorStudents",
                table: "InstractorStudents",
                columns: new[] { "StudentId", "InstractorId" });

            migrationBuilder.CreateIndex(
                name: "IX_InstractorStudents_InstractorId",
                table: "InstractorStudents",
                column: "InstractorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InstractorStudents",
                table: "InstractorStudents");

            migrationBuilder.DropIndex(
                name: "IX_InstractorStudents_InstractorId",
                table: "InstractorStudents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstractorStudents",
                table: "InstractorStudents",
                columns: new[] { "InstractorId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_InstractorStudents_StudentId",
                table: "InstractorStudents",
                column: "StudentId");
        }
    }
}
