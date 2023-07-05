using Assignment_C_4.ISevices;
using Assignment_C_4.Models;

namespace Assignment_C_4.Sevices
{
    public class HoaDonSevice : IHoaDonSevice
    {
        DepDbContext dbContext;

        public HoaDonSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateHoaDon(HoaDon p)
        {
            
                dbContext.HoaDons.Add(p);
                dbContext.SaveChanges();
                return true;
            
        }

        public bool DeleteHoaDon(Guid id)
        {
            try
            {
                var product = dbContext.HoaDons.Find(id);
                dbContext.HoaDons.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDon> GetAllBill()
        {
            return dbContext.HoaDons.ToList();
        }

        public bool UpdateHoaDon(HoaDon p)
        {
           
                var product = dbContext.HoaDons.Find(p.ID);
                product.NgayTao = p.NgayTao;
                product.NgayThanhToan = p.NgayThanhToan;
                product.TenKH = p.TenKH;
                product.SDT = p.SDT;
                product.TrangThai = p.TrangThai;
                product.TongTien= p.TongTien;
                dbContext.HoaDons.Update(product);
                dbContext.SaveChanges();
                return true;
           
        }
    }
}
