namespace Assignment_C_4.Models
{
    public class ChucVu
    {
        public string ID { get; set; }

        public string TenChucVu { get; set; }
        public string ThongTin { get; set; }
        public int TrangThai { get; set; }

        public virtual List<NguoiDung> NguoiDungs { get; set; }
    }
}
