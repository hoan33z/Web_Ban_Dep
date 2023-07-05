using Assignment_C_4.Models;

namespace Assignment_C_4.ISevices
{
    public interface IChucVuSevice
    {
        public bool CreateChucVu(ChucVu p);
        public bool UpdateChucVu(ChucVu p);
        public bool DeleteChucVu(Guid id);
        public ChucVu GetRoleById(string id);

    }
}
