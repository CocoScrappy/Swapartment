using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
  public partial class TestingWithDbSetsReqRemoved : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Rentals_AspNetUsers_RenterId",
          table: "Rentals");

      migrationBuilder.DropForeignKey(
          name: "FK_Rentals_Properties_PropertyId",
          table: "Rentals");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "b0452d7b-07af-4b4f-bfff-d327ee29a8c0");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "eb11abe2-c3b7-49ad-9af2-fbf7d3bc904b");

      migrationBuilder.AlterColumn<string>(
          name: "RenterId",
          table: "Rentals",
          type: "nvarchar(450)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(450)");

      migrationBuilder.AlterColumn<int>(
          name: "PropertyId",
          table: "Rentals",
          type: "int",
          nullable: true,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "04690483-46ef-4204-b69e-11e2ed11db70", "3e03d076-109c-4435-8057-feabffdbaa2f", "USER", "USER" });

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "43728271-a96a-4205-8a30-8a65921e6707", "656fffbb-1af1-44d7-bf65-a37381c46218", "ADMIN", "ADMIN" });

      migrationBuilder.AddForeignKey(
          name: "FK_Rentals_AspNetUsers_RenterId",
          table: "Rentals",
          column: "RenterId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.NoAction,
          onUpdate: ReferentialAction.NoAction);

      migrationBuilder.AddForeignKey(
          name: "FK_Rentals_Properties_PropertyId",
          table: "Rentals",
          column: "PropertyId",
          principalTable: "Properties",
          principalColumn: "Id",
          onDelete: ReferentialAction.NoAction,
          onUpdate: ReferentialAction.NoAction);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Rentals_AspNetUsers_RenterId",
          table: "Rentals");

      migrationBuilder.DropForeignKey(
          name: "FK_Rentals_Properties_PropertyId",
          table: "Rentals");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "04690483-46ef-4204-b69e-11e2ed11db70");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "43728271-a96a-4205-8a30-8a65921e6707");

      migrationBuilder.AlterColumn<string>(
          name: "RenterId",
          table: "Rentals",
          type: "nvarchar(450)",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "nvarchar(450)",
          oldNullable: true);

      migrationBuilder.AlterColumn<int>(
          name: "PropertyId",
          table: "Rentals",
          type: "int",
          nullable: false,
          defaultValue: 0,
          oldClrType: typeof(int),
          oldType: "int",
          oldNullable: true);

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "b0452d7b-07af-4b4f-bfff-d327ee29a8c0", "8bad4171-d9ef-448c-b3ec-9eb949e42124", "USER", "USER" });

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "eb11abe2-c3b7-49ad-9af2-fbf7d3bc904b", "ebf07507-df78-4107-a302-d62e3fba0bf0", "ADMIN", "ADMIN" });

      migrationBuilder.AddForeignKey(
          name: "FK_Rentals_AspNetUsers_RenterId",
          table: "Rentals",
          column: "RenterId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.NoAction);

      migrationBuilder.AddForeignKey(
          name: "FK_Rentals_Properties_PropertyId",
          table: "Rentals",
          column: "PropertyId",
          principalTable: "Properties",
          principalColumn: "Id",
          onDelete: ReferentialAction.NoAction);
    }
  }
}
