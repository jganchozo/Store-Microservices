using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Api.ShoppingCart.Migrations
{
    public partial class InitialMySQLMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartSession",
                columns: table => new
                {
                    ShoppingCartSessionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSession", x => x.ShoppingCartSessionId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartSessionDetail",
                columns: table => new
                {
                    ShoppingCartSessionDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    SelectedProduct = table.Column<string>(nullable: true),
                    ShoppingCartSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessionDetail", x => x.ShoppingCartSessionDetailId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartSessionDetail_ShoppingCartSession_ShoppingCartSe~",
                        column: x => x.ShoppingCartSessionId,
                        principalTable: "ShoppingCartSession",
                        principalColumn: "ShoppingCartSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartSessionDetail_ShoppingCartSessionId",
                table: "ShoppingCartSessionDetail",
                column: "ShoppingCartSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartSessionDetail");

            migrationBuilder.DropTable(
                name: "ShoppingCartSession");
        }
    }
}
