using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemo.Migrations
{
    public partial class goof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rok",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rok",
                table: "Person");
        }
    }
}
