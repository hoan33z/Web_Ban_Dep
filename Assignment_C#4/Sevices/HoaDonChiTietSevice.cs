using Assignment_C_4.ISevices;
using Assignment_C_4.Models;

namespace Assignment_C_4.Sevices
{
    public class HoaDonChiTietSevice : IHoaDonChiTietSevice
    {
        DepDbContext dbContext;

        public HoaDonChiTietSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                dbContext.HoaDonChiTiets.Add(p);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDonChiTiet(Guid id)
        {
            try
            {
                var product = dbContext.HoaDonChiTiets.Find(id);
                dbContext.HoaDonChiTiets.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDonChiTiet> GetAllBill()
        {
            return dbContext.HoaDonChiTiets.ToList();
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                var product = dbContext.HoaDonChiTiets.Find(p.ID);
                product.Gia = p.Gia;
                product.SoLuong = p.SoLuong;
                dbContext.HoaDonChiTiets.Update(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
