using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
    public partial class CascadeBackOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_SwapartmentUserId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "330e748c-9f94-46d9-8e75-335792f43c00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97df5b7f-000a-49fc-b0ec-423b604dc8a5");

            migrationBuilder.AlterColumn<string>(
                name: "SwapartmentUserId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db875001-db07-4481-9c46-0d84cfb28e74", "6c007189-e728-451e-b5de-14dcb36f9964", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd5657b0-5f15-4798-bbdf-699fc0456575", "fd1d64f3-0363-4c33-a0cc-e9d112f44a6c", "ADMIN", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_SwapartmentUserId",
                table: "Properties",
                column: "SwapartmentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_SwapartmentUserId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db875001-db07-4481-9c46-0d84cfb28e74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd5657b0-5f15-4798-bbdf-699fc0456575");

            migrationBuilder.AlterColumn<string>(
                name: "SwapartmentUserId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "330e748c-9f94-46d9-8e75-335792f43c00", "3d530e9c-aef2-4b0f-84fd-2aa782bda957", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97df5b7f-000a-49fc-b0ec-423b604dc8a5", "a6702384-a7ae-4341-8e37-5d5a9e345601", "ADMIN", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_SwapartmentUserId",
                table: "Properties",
                column: "SwapartmentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
