using Microsoft.EntityFrameworkCore.Migrations;

namespace coreApiProject.Migrations
{
    public partial class asdadsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Categories_CategoryID",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_CategoryID",
                table: "Todos");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Todos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CategoryID",
                table: "Todos",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Categories_CategoryID",
                table: "Todos",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
