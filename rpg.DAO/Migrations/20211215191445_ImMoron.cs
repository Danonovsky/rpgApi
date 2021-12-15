using Microsoft.EntityFrameworkCore.Migrations;

namespace rpg.DAO.Migrations
{
    public partial class ImMoron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Characters",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Characters",
                newName: "Path");
        }
    }
}
