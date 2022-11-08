using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
    public partial class WithTableAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "061adee3-27aa-4d55-b5a6-bfea1ea5ac1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4706dc6-4e24-4fb6-85bf-b2ecc539f458");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "61b9fe81-7981-4f14-bf73-0ab93420609f", "ef7c4387-afd6-4a98-bf14-a45fba23ff3f", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d30f316f-b673-4c18-b9c0-00d70dd1df8f", "b32b0ee6-485b-4d31-af49-7e29ff298140", "USER", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61b9fe81-7981-4f14-bf73-0ab93420609f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30f316f-b673-4c18-b9c0-00d70dd1df8f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "061adee3-27aa-4d55-b5a6-bfea1ea5ac1d", "4e79bac5-1369-41e8-b553-7888924e8589", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4706dc6-4e24-4fb6-85bf-b2ecc539f458", "85e26750-fd66-45a3-b5e4-d71fc8c4efaf", "ADMIN", "ADMIN" });
        }
    }
}
