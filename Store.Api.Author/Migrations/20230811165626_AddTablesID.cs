using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Api.Author.Migrations
{
    public partial class AddTablesID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degree_Author_AuthorId",
                table: "Degree");

            migrationBuilder.DropIndex(
                name: "IX_Degree_AuthorId",
                table: "Degree");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Degree");

            migrationBuilder.AddColumn<int>(
                name: "BookAuthorId",
                table: "Degree",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Degree_BookAuthorId",
                table: "Degree",
                column: "BookAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_Author_BookAuthorId",
                table: "Degree",
                column: "BookAuthorId",
                principalTable: "Author",
                principalColumn: "BookAuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degree_Author_BookAuthorId",
                table: "Degree");

            migrationBuilder.DropIndex(
                name: "IX_Degree_BookAuthorId",
                table: "Degree");

            migrationBuilder.DropColumn(
                name: "BookAuthorId",
                table: "Degree");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Degree",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Degree_AuthorId",
                table: "Degree",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_Author_AuthorId",
                table: "Degree",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "BookAuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
