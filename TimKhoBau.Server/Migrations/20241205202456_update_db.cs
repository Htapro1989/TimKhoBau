using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimKhoBau.Server.Migrations
{
    /// <inheritdoc />
    public partial class update_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rows",
                table: "TreasureMaps",
                newName: "n");

            migrationBuilder.RenameColumn(
                name: "Columns",
                table: "TreasureMaps",
                newName: "m");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "n",
                table: "TreasureMaps",
                newName: "Rows");

            migrationBuilder.RenameColumn(
                name: "m",
                table: "TreasureMaps",
                newName: "Columns");
        }
    }
}
