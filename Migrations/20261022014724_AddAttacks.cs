using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaggerheartProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAttacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DiceRoll = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Effects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaggerheartCharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attacks_DaggerheartCharacters_DaggerheartCharacterId",
                        column: x => x.DaggerheartCharacterId,
                        principalTable: "DaggerheartCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_DaggerheartCharacterId",
                table: "Attacks",
                column: "DaggerheartCharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attacks");
        }
    }
}
