using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonVu.Migrations
{
    /// <inheritdoc />
    public partial class ChapteFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_subjects_SubjectId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_Chapter_ChapterId",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter");

            migrationBuilder.RenameTable(
                name: "Chapter",
                newName: "chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Chapter_SubjectId",
                table: "chapters",
                newName: "IX_chapters_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chapters",
                table: "chapters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_chapters_subjects_SubjectId",
                table: "chapters",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_chapters_ChapterId",
                table: "questions",
                column: "ChapterId",
                principalTable: "chapters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chapters_subjects_SubjectId",
                table: "chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_chapters_ChapterId",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chapters",
                table: "chapters");

            migrationBuilder.RenameTable(
                name: "chapters",
                newName: "Chapter");

            migrationBuilder.RenameIndex(
                name: "IX_chapters_SubjectId",
                table: "Chapter",
                newName: "IX_Chapter_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_subjects_SubjectId",
                table: "Chapter",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_Chapter_ChapterId",
                table: "questions",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id");
        }
    }
}
