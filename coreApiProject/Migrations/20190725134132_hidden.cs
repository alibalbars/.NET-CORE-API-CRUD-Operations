using Microsoft.EntityFrameworkCore.Migrations;

namespace coreApiProject.Migrations
{
    public partial class hidden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Todos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Categories");
        }
    }
}
