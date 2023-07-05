using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface IHoaDonChiTietSevice
    {
        public bool CreateHoaDonChiTiet(HoaDonChiTiet p);
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p);
        public bool DeleteHoaDonChiTiet(Guid id);
        public List<HoaDonChiTiet> GetAllBill();
    }
}
