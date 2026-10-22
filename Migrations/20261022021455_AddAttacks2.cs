using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DaggerheartProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAttacks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attacks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Attacks",
                columns: new[] { "Id", "DaggerheartCharacterId", "DiceRoll", "Effects", "Modifier", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, 8, "", 1, "Sword", "Physical" },
                    { 2, 3, 6, "", 1, "Bow", "Physical" },
                    { 3, 2, 10, "Sets target on fire", 2, "Fireball", "Magic" },
                    { 4, 3, 4, "", 0, "Unarmed", "Physical" },
                    { 5, 4, 10, "", 1, "Magic Gauntlets", "Magic" },
                    { 6, 5, 6, "Can be used as secondary weapon", 0, "Dagger", "Physical" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attacks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attacks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attacks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attacks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attacks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attacks");
        }
    }
}
