using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    public partial class TableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableData",
                table: "ImportSource",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableData",
                table: "ImportSource");
        }
    }
}
