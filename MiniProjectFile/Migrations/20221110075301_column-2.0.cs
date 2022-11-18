using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjectFile.Migrations
{
    public partial class column20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnModel_ImportSource_ImportSourceId",
                table: "ColumnModel");

            migrationBuilder.AlterColumn<int>(
                name: "ImportSourceId",
                table: "ColumnModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnModel_ImportSource_ImportSourceId",
                table: "ColumnModel",
                column: "ImportSourceId",
                principalTable: "ImportSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnModel_ImportSource_ImportSourceId",
                table: "ColumnModel");

            migrationBuilder.AlterColumn<int>(
                name: "ImportSourceId",
                table: "ColumnModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnModel_ImportSource_ImportSourceId",
                table: "ColumnModel",
                column: "ImportSourceId",
                principalTable: "ImportSource",
                principalColumn: "Id");
        }
    }
}
