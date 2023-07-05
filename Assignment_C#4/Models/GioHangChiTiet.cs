
namespace Assignment_C_4.Models
{
    public class GioHangChiTiet
    {
        public Guid ID { get; set; }
        public Guid IDND { get; set; }
        public Guid IDSP { get; set; }
        public int SoLuong { get; set; }
        public virtual SanPham SanPhams { get; set; }
        public virtual GioHang GioHangs { get; set; }

    }
}
