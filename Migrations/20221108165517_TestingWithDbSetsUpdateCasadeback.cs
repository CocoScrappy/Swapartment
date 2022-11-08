using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
    public partial class TestingWithDbSetsUpdateCasadeback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04690483-46ef-4204-b69e-11e2ed11db70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43728271-a96a-4205-8a30-8a65921e6707");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "330e748c-9f94-46d9-8e75-335792f43c00", "3d530e9c-aef2-4b0f-84fd-2aa782bda957", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97df5b7f-000a-49fc-b0ec-423b604dc8a5", "a6702384-a7ae-4341-8e37-5d5a9e345601", "ADMIN", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330e748c-9f94-46d9-8e75-335792f43c00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97df5b7f-000a-49fc-b0ec-423b604dc8a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04690483-46ef-4204-b69e-11e2ed11db70", "3e03d076-109c-4435-8057-feabffdbaa2f", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43728271-a96a-4205-8a30-8a65921e6707", "656fffbb-1af1-44d7-bf65-a37381c46218", "ADMIN", "ADMIN" });
        }
    }
}
