using Assignment_C_4.ISevices;
using Assignment_C_4.Models;

namespace Assignment_C_4.Sevices
{
    public class NguoiDungSevice : INguoiDungSevice
    {
        DepDbContext dbContext;

        public NguoiDungSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateNguoiDung(NguoiDung p)
        {
            p.IDCV = "KH";
            p.TrangThai = 0;
            dbContext.Add(p);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteNguoiDung(Guid id)
        {
            try
            {
                var product = dbContext.NguoiDungs.Find(id);
                dbContext.NguoiDungs.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public NguoiDung GetProductsByName(string name)
        {
            return dbContext.NguoiDungs.FirstOrDefault(p => p.TenND == name);
        }

        public bool UpdateNguoiDung(NguoiDung p)
        {
            try
            {
                var product = dbContext.NguoiDungs.Find(p.IDND);

                product.TenND = p.TenND;
                product.SDT = p.SDT;
                product.TaiKhoan = p.TaiKhoan;
                product.MatKhau = p.TaiKhoan;
                product.TrangThai = p.TrangThai;
                product.IDCV = p.IDCV;
                dbContext.NguoiDungs.Update(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<NguoiDung> GetAllUser()
        {
            return dbContext.NguoiDungs.ToList();
        }
    }
}
