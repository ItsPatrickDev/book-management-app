using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksManager.Data.Migrations
{
    public partial class FixShelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
