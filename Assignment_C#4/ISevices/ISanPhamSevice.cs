using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface ISanPhamSevice
    {
        public bool CreateProduct(SanPham p);
        public bool UpdateProduct(SanPham p);
        public bool DeleteProduct(Guid id);
        public List<SanPham> GetAllProducts();
        public SanPham GetProductById(Guid id);
        public List<SanPham> GetProductsByName(string name);

    }
}
