using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface IGioHangSevice
    {
        public bool CreateGioHang(GioHang p);
        public bool UpdateGioHang(GioHang p);
        public bool DeleteGioHang(Guid id);

    }
}
