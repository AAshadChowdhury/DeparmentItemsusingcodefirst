using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreShortProject.Migrations
{
    public partial class secondtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "available",
                table: "items2",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "available",
                table: "items2");
        }
    }
}
