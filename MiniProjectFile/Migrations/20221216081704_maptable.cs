using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    /// <inheritdoc />
    public partial class maptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainData",
                table: "ImportSource");

            migrationBuilder.CreateTable(
                name: "ProductMapValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductHeader = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMapValue", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMapValue");

            migrationBuilder.AddColumn<string>(
                name: "MainData",
                table: "ImportSource",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
