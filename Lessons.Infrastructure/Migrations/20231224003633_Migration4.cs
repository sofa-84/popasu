using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lessons.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Groups_Number",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Number",
                table: "Groups",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_Number",
                table: "Groups");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Groups_Number",
                table: "Groups",
                column: "Number");
        }
    }
}
