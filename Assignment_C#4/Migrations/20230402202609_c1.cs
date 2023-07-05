using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_C_4.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_GioHang_IDND",
                table: "NguoiDung",
                column: "IDND",
                principalTable: "GioHang",
                principalColumn: "IDND",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_GioHang_IDND",
                table: "NguoiDung");
        }
    }
}
