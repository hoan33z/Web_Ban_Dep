using Assignment_C_4.ISevices;
using Assignment_C_4.Models;

namespace Assignment_C_4.Sevices
{
    public class GioHangSevice : IGioHangSevice
    {
        DepDbContext dbContext;

        public GioHangSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateGioHang(GioHang p)
        {
            try
            {
                dbContext.Add(p);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGioHang(Guid id)
        {
            try
            {
                var product = dbContext.GioHangs.Find(id);
                dbContext.GioHangs.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateGioHang(GioHang p)
        {
            try
            {
                var product = dbContext.GioHangs.Find(p.IDND);
                product.ThongTin = p.ThongTin;
                dbContext.GioHangs.Update(product);
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
