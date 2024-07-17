using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace light_eyes.Migrations
{
    /// <inheritdoc />
    public partial class checkListItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dcc8cef-263c-4a84-894e-362ed0d2f886");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a870c5c2-d08a-4b63-855a-d935de8c877f");

            migrationBuilder.CreateTable(
                name: "CheckListItem",
                columns: table => new
                {
                    CheckListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItem", x => x.CheckListItemId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72b44963-e2b2-4d84-83bf-81bfddb5f609", null, "Admin", "ADMIN" },
                    { "8df2b7b8-bd0e-48e1-bf20-ddc5b724de66", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListItem");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b44963-e2b2-4d84-83bf-81bfddb5f609");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8df2b7b8-bd0e-48e1-bf20-ddc5b724de66");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dcc8cef-263c-4a84-894e-362ed0d2f886", null, "User", "USER" },
                    { "a870c5c2-d08a-4b63-855a-d935de8c877f", null, "Admin", "ADMIN" }
                });
        }
    }
}
