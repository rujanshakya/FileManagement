using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    public partial class ColumnModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColumnModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportSourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColumnModel_ImportSource_ImportSourceId",
                        column: x => x.ImportSourceId,
                        principalTable: "ImportSource",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnModel_ImportSourceId",
                table: "ColumnModel",
                column: "ImportSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnModel");
        }
    }
}
