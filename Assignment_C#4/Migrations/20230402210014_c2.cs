using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_C_4.Migrations
{
    public partial class c2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_GioHang_IDND",
                table: "NguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_NguoiDung_IDND",
                table: "GioHang",
                column: "IDND",
                principalTable: "NguoiDung",
                principalColumn: "IDND",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_NguoiDung_IDND",
                table: "GioHang");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_GioHang_IDND",
                table: "NguoiDung",
                column: "IDND",
                principalTable: "GioHang",
                principalColumn: "IDND",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
