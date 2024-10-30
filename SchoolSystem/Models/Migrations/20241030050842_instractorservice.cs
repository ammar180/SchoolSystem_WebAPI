using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class instractorservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instractor_Subjects_SubjectId",
                table: "Instractor");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instractor_InstractorId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instractor",
                table: "Instractor");

            migrationBuilder.RenameTable(
                name: "Instractor",
                newName: "Instractors");

            migrationBuilder.RenameIndex(
                name: "IX_Instractor_SubjectId",
                table: "Instractors",
                newName: "IX_Instractors_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instractors",
                table: "Instractors",
                column: "InstractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Subjects_SubjectId",
                table: "Instractors",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instractors_InstractorId",
                table: "Students",
                column: "InstractorId",
                principalTable: "Instractors",
                principalColumn: "InstractorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Subjects_SubjectId",
                table: "Instractors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instractors_InstractorId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instractors",
                table: "Instractors");

            migrationBuilder.RenameTable(
                name: "Instractors",
                newName: "Instractor");

            migrationBuilder.RenameIndex(
                name: "IX_Instractors_SubjectId",
                table: "Instractor",
                newName: "IX_Instractor_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instractor",
                table: "Instractor",
                column: "InstractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instractor_Subjects_SubjectId",
                table: "Instractor",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instractor_InstractorId",
                table: "Students",
                column: "InstractorId",
                principalTable: "Instractor",
                principalColumn: "InstractorId");
        }
    }
}
