using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lessons.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonRole",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonType",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonRole",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LessonType",
                table: "Lessons");
        }
    }
}
