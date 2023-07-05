using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_C_4.Migrations
{
    public partial class c4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TongTien",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "HoaDon");
        }
    }
}
