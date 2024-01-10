using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lessons.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Lectures_LectureId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_LectureId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Groups");

            migrationBuilder.CreateTable(
                name: "GroupLecture",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    LecturesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLecture", x => new { x.GroupsId, x.LecturesId });
                    table.ForeignKey(
                        name: "FK_GroupLecture_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLecture_Lectures_LecturesId",
                        column: x => x.LecturesId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupLecture_LecturesId",
                table: "GroupLecture",
                column: "LecturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupLecture");

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Groups",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LectureId",
                table: "Groups",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Lectures_LectureId",
                table: "Groups",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id");
        }
    }
}
