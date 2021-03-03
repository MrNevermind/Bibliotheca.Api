using Microsoft.EntityFrameworkCore.Migrations;

namespace Bibliotheca.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AccountTable",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTable",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTable_AccountTable_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "AccountTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTable_AccountId",
                schema: "dbo",
                table: "BookTable",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTable_Status",
                schema: "dbo",
                table: "BookTable",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTable",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AccountTable",
                schema: "dbo");
        }
    }
}
