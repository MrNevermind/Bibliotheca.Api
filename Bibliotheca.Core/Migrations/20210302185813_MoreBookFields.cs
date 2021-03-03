using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bibliotheca.Core.Migrations
{
    public partial class MoreBookFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                schema: "dbo",
                table: "BookTable",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                schema: "dbo",
                table: "BookTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                schema: "dbo",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "Cover",
                schema: "dbo",
                table: "BookTable");
        }
    }
}
