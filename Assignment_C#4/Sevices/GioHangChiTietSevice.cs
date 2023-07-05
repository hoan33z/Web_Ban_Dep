using Assignment_C_4.ISevices;
using Assignment_C_4.Models;

namespace Assignment_C_4.Sevices
{
    public class GioHangChiTietSevice : IGioHangChiTietSevice
    {
        DepDbContext dbContext;

        public GioHangChiTietSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateGioHangChiTiet(GioHangChiTiet p)
        {
            
                dbContext.GioHangChiTiets.Add(p);
                dbContext.SaveChanges();
                return true;
           
        }

        public bool DeleteGioHangChiTiet(Guid id)
        {
            try
            {
                var product = dbContext.GioHangChiTiets.Find(id);
                dbContext.GioHangChiTiets.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GioHangChiTiet> GetAllCartDetails()
        {
            return dbContext.GioHangChiTiets.ToList();
        }

        public GioHangChiTiet GetCartDetailById(Guid id)
        {
            return dbContext.GioHangChiTiets.FirstOrDefault(c=>c.IDSP==id);
        }

        public bool UpdateGioHangChiTiet(GioHangChiTiet p)
        {
            try
            {
                var product = dbContext.GioHangChiTiets.Find(p.ID);
                product.SoLuong = p.SoLuong;
                dbContext.GioHangChiTiets.Update(product);
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
