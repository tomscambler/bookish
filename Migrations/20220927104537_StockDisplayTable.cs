using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookish.Migrations
{
    public partial class StockDisplayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Stock");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Stock",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Stock",
                type: "text",
                nullable: true);
        }
    }
}
