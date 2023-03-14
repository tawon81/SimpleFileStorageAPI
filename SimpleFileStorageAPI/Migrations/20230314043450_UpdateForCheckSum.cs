using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleFileStorageAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForCheckSum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckSum",
                table: "ApiFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckSum",
                table: "ApiFiles");
        }
    }
}
