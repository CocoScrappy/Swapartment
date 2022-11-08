using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
  public partial class TestingWithDbSets : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "61b9fe81-7981-4f14-bf73-0ab93420609f");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "d30f316f-b673-4c18-b9c0-00d70dd1df8f");

      migrationBuilder.CreateTable(
          name: "Properties",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
            DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            NumberOfBedrooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
            NumberOfBathrooms = table.Column<string>(type: "nvarchar(max)", nullable: false),
            UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            StreetAddress = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
            State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
            Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            SwapartmentUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Properties", x => x.Id);
            table.ForeignKey(
                      name: "FK_Properties_AspNetUsers_SwapartmentUserId",
                      column: x => x.SwapartmentUserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "PropertyImages",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            PropertyId = table.Column<int>(type: "int", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PropertyImages", x => x.Id);
            table.ForeignKey(
                      name: "FK_PropertyImages_Properties_PropertyId",
                      column: x => x.PropertyId,
                      principalTable: "Properties",
                      principalColumn: "Id");
          });

      migrationBuilder.CreateTable(
          name: "PropertyTags",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
            IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            PropertyId = table.Column<int>(type: "int", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PropertyTags", x => x.Id);
            table.ForeignKey(
                      name: "FK_PropertyTags_Properties_PropertyId",
                      column: x => x.PropertyId,
                      principalTable: "Properties",
                      principalColumn: "Id");
          });

      migrationBuilder.CreateTable(
          name: "Rentals",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            PriceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            isPaid = table.Column<bool>(type: "bit", nullable: false),
            Feedback = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
            PropertyId = table.Column<int>(type: "int", nullable: false),
            RenterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Rentals", x => x.Id);
            table.ForeignKey(
                      name: "FK_Rentals_AspNetUsers_RenterId",
                      column: x => x.RenterId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Rentals_Properties_PropertyId",
                      column: x => x.PropertyId,
                      principalTable: "Properties",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction);
          });

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "b0452d7b-07af-4b4f-bfff-d327ee29a8c0", "8bad4171-d9ef-448c-b3ec-9eb949e42124", "USER", "USER" });

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "eb11abe2-c3b7-49ad-9af2-fbf7d3bc904b", "ebf07507-df78-4107-a302-d62e3fba0bf0", "ADMIN", "ADMIN" });

      migrationBuilder.CreateIndex(
          name: "IX_Properties_SwapartmentUserId",
          table: "Properties",
          column: "SwapartmentUserId");

      migrationBuilder.CreateIndex(
          name: "IX_PropertyImages_PropertyId",
          table: "PropertyImages",
          column: "PropertyId");

      migrationBuilder.CreateIndex(
          name: "IX_PropertyTags_PropertyId",
          table: "PropertyTags",
          column: "PropertyId");

      migrationBuilder.CreateIndex(
          name: "IX_Rentals_PropertyId",
          table: "Rentals",
          column: "PropertyId");

      migrationBuilder.CreateIndex(
          name: "IX_Rentals_RenterId",
          table: "Rentals",
          column: "RenterId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "PropertyImages");

      migrationBuilder.DropTable(
          name: "PropertyTags");

      migrationBuilder.DropTable(
          name: "Rentals");

      migrationBuilder.DropTable(
          name: "Properties");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "b0452d7b-07af-4b4f-bfff-d327ee29a8c0");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "eb11abe2-c3b7-49ad-9af2-fbf7d3bc904b");

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "61b9fe81-7981-4f14-bf73-0ab93420609f", "ef7c4387-afd6-4a98-bf14-a45fba23ff3f", "ADMIN", "ADMIN" });

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "d30f316f-b673-4c18-b9c0-00d70dd1df8f", "b32b0ee6-485b-4d31-af49-7e29ff298140", "USER", "USER" });
    }
  }
}
