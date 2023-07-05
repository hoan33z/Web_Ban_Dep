using Assignment_C_4.ISevices;
using Assignment_C_4.Models;
using System.Linq;

namespace Assignment_C_4.Sevices
{
    public class SanPhamSevice : ISanPhamSevice
    {
        DepDbContext dbContext;

        public SanPhamSevice()
        {
            dbContext = new DepDbContext();
        }

        public bool CreateProduct(SanPham p)
        {
            try
            {
                dbContext.SanPhams.Add(p);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = dbContext.SanPhams.Find(id);
                dbContext.SanPhams.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SanPham> GetAllProducts()
        {
            return dbContext.SanPhams.ToList();
        }

        public SanPham GetProductById(Guid id)
        {
            return dbContext.SanPhams.FirstOrDefault(p => p.ID == id);
        }

        public List<SanPham> GetProductsByName(string name)
        {
            return dbContext.SanPhams.Where(p => p.TenSP == name).ToList();
        }

        public bool UpdateProduct(SanPham p)
        {
            try
            {
                var product = dbContext.SanPhams.Find(p.ID);
                product.TenSP = p.TenSP;
                product.GiaBan = p.GiaBan;
                product.GiaNhap = p.GiaNhap;
                product.Mau = p.Mau;
                product.KichCo = p.KichCo;
                product.TrangThai = p.TrangThai;
                product.SoLongTon = p.SoLongTon;
                product.HinhAnh = p.HinhAnh;
                dbContext.SanPhams.Update(product);
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
