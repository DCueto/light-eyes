using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace light_eyes.Migrations
{
    /// <inheritdoc />
    public partial class checkListItemOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72b44963-e2b2-4d84-83bf-81bfddb5f609");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8df2b7b8-bd0e-48e1-bf20-ddc5b724de66");

            migrationBuilder.CreateTable(
                name: "CheckListItemOption",
                columns: table => new
                {
                    CheckListItemOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPositive = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckListItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItemOption", x => x.CheckListItemOptionId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22564874-e66c-490a-b8c7-adf6203e28e1", null, "User", "USER" },
                    { "3b67a278-700f-404a-99f0-5a34f13f562a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListItemOption");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22564874-e66c-490a-b8c7-adf6203e28e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b67a278-700f-404a-99f0-5a34f13f562a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72b44963-e2b2-4d84-83bf-81bfddb5f609", null, "Admin", "ADMIN" },
                    { "8df2b7b8-bd0e-48e1-bf20-ddc5b724de66", null, "User", "USER" }
                });
        }
    }
}
