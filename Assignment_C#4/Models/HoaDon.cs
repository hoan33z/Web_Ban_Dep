namespace Assignment_C_4.Models
{
    public class HoaDon
    {
        public Guid ID { get; set; }
        public Guid IDND { get; set; }

        public DateTime NgayTao { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int TongTien { get; set; }

        public string TenKH { get; set; }
        public int SDT { get; set; }
        public int TrangThai { get; set; }

        public virtual NguoiDung NguoiDungs { get; set; }
        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
