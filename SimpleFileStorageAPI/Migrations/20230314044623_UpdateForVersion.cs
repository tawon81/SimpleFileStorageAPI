using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleFileStorageAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Version",
                table: "ApiFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "ApiFiles");
        }
    }
}
