using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseplantAPI.Migrations
{
    /// <inheritdoc />
    public partial class HouseplantSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houseplants",
                columns: new[] { "Id", "CategoryId", "Leaves", "Name" },
                values: new object[] { 1, 1, 3, "Monstera" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houseplants",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
