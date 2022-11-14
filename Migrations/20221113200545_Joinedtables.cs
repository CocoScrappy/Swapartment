using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swapartment.Migrations
{
    public partial class Joinedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTags_Properties_PropertyId",
                table: "PropertyTags");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTags_PropertyId",
                table: "PropertyTags");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db875001-db07-4481-9c46-0d84cfb28e74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd5657b0-5f15-4798-bbdf-699fc0456575");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PropertyTags");

            migrationBuilder.CreateTable(
                name: "PropertyPropertyTag",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    PropertyTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPropertyTag", x => new { x.PropertyId, x.PropertyTagsId });
                    table.ForeignKey(
                        name: "FK_PropertyPropertyTag_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyPropertyTag_PropertyTags_PropertyTagsId",
                        column: x => x.PropertyTagsId,
                        principalTable: "PropertyTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0b7bd94-a395-47e8-b313-6bbbd38e3cc0", "b0a5e97c-6f56-4196-988a-96f7ff48a153", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b88ad719-8592-4b1d-822b-cb39b3ab53e8", "5617e309-c066-4222-9017-8aa3c5b840bc", "ADMIN", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPropertyTag_PropertyTagsId",
                table: "PropertyPropertyTag",
                column: "PropertyTagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyPropertyTag");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0b7bd94-a395-47e8-b313-6bbbd38e3cc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b88ad719-8592-4b1d-822b-cb39b3ab53e8");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "PropertyTags",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db875001-db07-4481-9c46-0d84cfb28e74", "6c007189-e728-451e-b5de-14dcb36f9964", "USER", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd5657b0-5f15-4798-bbdf-699fc0456575", "fd1d64f3-0363-4c33-a0cc-e9d112f44a6c", "ADMIN", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTags_PropertyId",
                table: "PropertyTags",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTags_Properties_PropertyId",
                table: "PropertyTags",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
