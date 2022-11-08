using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
    public partial class ChangedPropertyAndTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30c307d4-87fd-43a1-84bc-ea79a9ef4038");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d6d14c7-1e16-4282-b968-806e7bbd4ffc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "061adee3-27aa-4d55-b5a6-bfea1ea5ac1d", "4e79bac5-1369-41e8-b553-7888924e8589", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4706dc6-4e24-4fb6-85bf-b2ecc539f458", "85e26750-fd66-45a3-b5e4-d71fc8c4efaf", "ADMIN", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "30c307d4-87fd-43a1-84bc-ea79a9ef4038", "0c3ea828-3a48-410b-b729-ea20bd10bac1", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d6d14c7-1e16-4282-b968-806e7bbd4ffc", "3902883d-3191-4a80-89ef-c25f4926989d", "ADMIN", "ADMIN" });
        }
    }
}
