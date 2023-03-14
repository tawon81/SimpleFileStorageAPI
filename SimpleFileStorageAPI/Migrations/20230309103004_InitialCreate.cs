using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleFileStorageAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiFiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FileData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    FileType = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<decimal>(type: "DECIMAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiFiles", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiFiles");
        }
    }
}
