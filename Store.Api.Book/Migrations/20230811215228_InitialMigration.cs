using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Api.Book.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookModelId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: true),
                    AuthorGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
