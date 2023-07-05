namespace Assignment_C_4.Models
{
    public class GioHang
    {
        public Guid IDND { get; set; }
        public string ThongTin { get; set; }

        // public virtual NguoiDung NguoiDungs { get; set; }
        public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }
        public virtual NguoiDung NguoiDungs { get; set; }

    }
}
