using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseplantAPI.Migrations
{
    /// <inheritdoc />
    public partial class HouseplantLargerSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houseplants",
                columns: new[] { "Id", "CategoryId", "Leaves", "Name" },
                values: new object[,]
                {
                    { 2, 1, 20, "Rubber Tree" },
                    { 3, 3, 12, "Haworthia" },
                    { 4, 2, 19, "African Violet" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houseplants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Houseplants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Houseplants",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
