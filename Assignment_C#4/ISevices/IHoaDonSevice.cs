using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface IHoaDonSevice
    {
        public bool CreateHoaDon(HoaDon p);
        public bool UpdateHoaDon(HoaDon p);
        public bool DeleteHoaDon(Guid id);
        public List<HoaDon> GetAllBill();

    }
}
