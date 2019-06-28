using Microsoft.EntityFrameworkCore.Migrations;

namespace Monolith.DAL.Migrations
{
    public partial class AddedTechnicalNameToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TechnicalCategory",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechnicalCategory",
                table: "Categories");
        }
    }
}
