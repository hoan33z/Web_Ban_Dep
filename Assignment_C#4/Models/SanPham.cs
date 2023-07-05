
namespace Assignment_C_4.Models
{
    public class SanPham
    {
        public Guid ID { get; set; }

        public string TenSP { get; set; }
        public string Mau { get; set; }
        public int KichCo { get; set; }
        public int GiaBan { get; set; }
        public int GiaNhap { get; set; }
        public int SoLongTon { get; set; }
        public int TrangThai { get; set; }
        public string HinhAnh { get; set; }

        public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }
        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
