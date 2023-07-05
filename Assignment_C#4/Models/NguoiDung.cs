

namespace Assignment_C_4.Models
{
    public class NguoiDung
    {
        public Guid IDND { get; set; }
        public string IDCV { get; set; }

        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public string TenND { get; set; }
        public int SDT { get; set; }

        public int TrangThai { get; set; }

        public virtual List<HoaDon> HoaDons { get; set; }
        public virtual ChucVu ChucVus { get; set; }
        public virtual GioHang GioHangs { get; set; }
    }
}
