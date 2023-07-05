using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface IGioHangChiTietSevice
    {
        public bool CreateGioHangChiTiet(GioHangChiTiet p);
        public bool UpdateGioHangChiTiet(GioHangChiTiet p);
        public bool DeleteGioHangChiTiet(Guid id);
        public List<GioHangChiTiet> GetAllCartDetails();
        public GioHangChiTiet GetCartDetailById(Guid id);

    }
}
