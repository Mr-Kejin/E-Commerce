using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodWillStones.Migrations
{
    /// <inheritdoc />
    public partial class seedcategrytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "lCategory_ID", "sDescription", "sDisplayOrder" },
                values: new object[,]
                {
                    { 1, "Brick", 1 },
                    { 2, "M-Sand", 2 },
                    { 3, "P-Sand", 3 },
                    { 4, "Blue-Metal", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "lCategory_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "lCategory_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "lCategory_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "lCategory_ID",
                keyValue: 4);
        }
    }
}
