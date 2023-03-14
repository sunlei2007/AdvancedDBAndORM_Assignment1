using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedDBAndORM_Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB1051 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongVersionPlayListVM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongVersionID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: true),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: true),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: true),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersionPlayListVM", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongVersionPlayListVM");
        }
    }
}
