using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    /// <inheritdoc />
    public partial class DestinationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomModel",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomModel");
        }
    }
}
