using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface INguoiDungSevice
    {
        public bool CreateNguoiDung(NguoiDung p);
        public bool UpdateNguoiDung(NguoiDung p);
        public bool DeleteNguoiDung(Guid id);
        public NguoiDung GetProductsByName(string name);
        public List<NguoiDung> GetAllUser();

    }
}
