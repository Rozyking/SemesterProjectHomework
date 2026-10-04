using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DaggerheartProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaggerheartCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Evasion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaggerheartCharacters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DaggerheartCharacters",
                columns: new[] { "Id", "Class", "Evasion", "HitPoints", "Name" },
                values: new object[,]
                {
                    { 1, "Warrior", 11, 6, "Chug Fligadoo" },
                    { 2, "Druid", 10, 6, "Norman Chesnut" },
                    { 3, "Wizard", 11, 5, "Ena" },
                    { 4, "Rogue", 12, 6, "Rusty Peters" },
                    { 5, "Seraph", 9, 7, "Jebadiah Jemsen" },
                    { 6, "Guardian", 9, 7, "Charles Limburger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaggerheartCharacters");
        }
    }
}
