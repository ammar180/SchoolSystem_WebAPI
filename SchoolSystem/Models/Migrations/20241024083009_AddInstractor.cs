using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddInstractor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstractorId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instractor",
                columns: table => new
                {
                    InstractorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instractor", x => x.InstractorId);
                    table.ForeignKey(
                        name: "FK_Instractor_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_InstractorId",
                table: "Students",
                column: "InstractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Instractor_SubjectId",
                table: "Instractor",
                column: "SubjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Instractor_InstractorId",
                table: "Students",
                column: "InstractorId",
                principalTable: "Instractor",
                principalColumn: "InstractorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Instractor_InstractorId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Instractor");

            migrationBuilder.DropIndex(
                name: "IX_Students_InstractorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InstractorId",
                table: "Students");
        }
    }
}
