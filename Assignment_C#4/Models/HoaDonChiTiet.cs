namespace Assignment_C_4.Models
{
    public class HoaDonChiTiet
    {
        public Guid ID { get; set; }

        public Guid IDHD { get; set; }
        public Guid IDSP { get; set; }

        public int SoLuong { get; set; }
        public int Gia { get; set; }

        public virtual SanPham SanPhams { get; set; }
        public virtual HoaDon HoaDons { get; set; }
    }
}
