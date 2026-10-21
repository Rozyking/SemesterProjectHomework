using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaggerheartProject.Migrations
{
    /// <inheritdoc />
    public partial class AddDamageThresholds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LowerDamageThreshold",
                table: "DaggerheartCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperDamageThreshold",
                table: "DaggerheartCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DaggerheartCharacters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LowerDamageThreshold", "UpperDamageThreshold" },
                values: new object[] { 10, 17 });

            migrationBuilder.UpdateData(
                table: "DaggerheartCharacters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LowerDamageThreshold", "UpperDamageThreshold" },
                values: new object[] { 8, 15 });

            migrationBuilder.UpdateData(
                table: "DaggerheartCharacters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LowerDamageThreshold", "UpperDamageThreshold" },
                values: new object[] { 7, 14 });

            migrationBuilder.UpdateData(
                table: "DaggerheartCharacters",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LowerDamageThreshold", "UpperDamageThreshold" },
                values: new object[] { 19, 15 });

            migrationBuilder.UpdateData(
                table: "DaggerheartCharacters",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LowerDamageThreshold", "UpperDamageThreshold" },
                values: new object[] { 10, 16 });

            migrationBuilder.UpdateData(
                table: "DaggerheartCharacters",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "LowerDamageThreshold", "UpperDamageThreshold" },
                values: new object[] { 12, 19 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowerDamageThreshold",
                table: "DaggerheartCharacters");

            migrationBuilder.DropColumn(
                name: "UpperDamageThreshold",
                table: "DaggerheartCharacters");
        }
    }
}
