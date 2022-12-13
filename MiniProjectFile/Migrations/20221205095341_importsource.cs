using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    /// <inheritdoc />
    public partial class importsource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
