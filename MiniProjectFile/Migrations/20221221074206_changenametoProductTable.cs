using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    /// <inheritdoc />
    public partial class changenametoProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTab",
                table: "ProductTab");

            migrationBuilder.RenameTable(
                name: "ProductTab",
                newName: "ProductTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTable",
                table: "ProductTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTable",
                table: "ProductTable");

            migrationBuilder.RenameTable(
                name: "ProductTable",
                newName: "ProductTab");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTab",
                table: "ProductTab",
                column: "Id");
        }
    }
}
