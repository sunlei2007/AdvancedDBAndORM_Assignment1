using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedDBAndORM_Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB1215 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Librarys_Users_UserID",
                table: "Librarys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Librarys_UserID",
                table: "Librarys");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Librarys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Librarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Librarys_UserID",
                table: "Librarys",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Librarys_Users_UserID",
                table: "Librarys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
