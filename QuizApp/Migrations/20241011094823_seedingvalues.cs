using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class seedingvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "quiz_id", "Topic" },
                values: new object[,]
                {
                    { 1, "SQL" },
                    { 2, "C#" },
                    { 3, ".Net" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionId", "CorrectOption", "CreatedAt", "CreatedBy", "Difficulty", "OptionA", "OptionB", "OptionC", "OptionD", "QuestionText", "QuizId", "TimeLimitInSeconds" },
                values: new object[] { 1, "University of California, Berkeley", 1, 1, "easy", "MIT", "Harvard", "University of California, Berkeley", "Tsinghua University, Beijing", "In which University was PostGres Developed", 1, 30 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quiz",
                keyColumn: "quiz_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quiz",
                keyColumn: "quiz_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quiz",
                keyColumn: "quiz_id",
                keyValue: 1);
        }
    }
}
