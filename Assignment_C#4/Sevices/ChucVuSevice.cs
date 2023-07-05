using Assignment_C_4.ISevices;
using Assignment_C_4.Models;

namespace Assignment_C_4.Sevices
{
    public class ChucVuSevice : IChucVuSevice
    {
        DepDbContext dbContext;

        public ChucVuSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateChucVu(ChucVu p)
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

        public bool DeleteChucVu(Guid id)
        {
            try
            {
                var product = dbContext.ChucVus.Find(id);
                dbContext.ChucVus.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateChucVu(ChucVu p)
        {
            try
            {
                var product = dbContext.ChucVus.Find(p.ID);
                product.TenChucVu = p.TenChucVu;
                product.ThongTin = p.ThongTin;
                product.TrangThai = p.TrangThai;
                dbContext.ChucVus.Update(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ChucVu GetRoleById(string id)
        {
            return dbContext.ChucVus.FirstOrDefault(p => p.ID == id);
        }

    }
}
