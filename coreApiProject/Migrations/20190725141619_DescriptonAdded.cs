using Microsoft.EntityFrameworkCore.Migrations;

namespace coreApiProject.Migrations
{
    public partial class DescriptonAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Todo",
                table: "Todos",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Todos",
                newName: "Todo");
        }
    }
}
