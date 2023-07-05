using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_C_4.Models
{
    public class DepDbContext : DbContext
    {
        public DepDbContext()
        {
        }

        public DepDbContext(DbContextOptions<DepDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.
                UseSqlServer("Data Source=DESKTOP-ECEQI3B;Initial Catalog=C#4;Integrated Security=True"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }


    }
}
