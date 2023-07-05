using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class HoaDOnConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(k => k.ID);
            builder.Property(c => c.NgayTao).HasColumnType("datetime");
            builder.Property(c => c.NgayThanhToan).HasColumnType("datetime");
            builder.Property(c => c.TenKH).HasColumnType("nvarchar(50)");
            builder.Property(c => c.SDT).HasColumnType("int");
            builder.Property(c => c.TongTien).HasColumnType("int");
            builder.Property(c => c.TrangThai).HasColumnType("int");

            builder.HasOne(x => x.NguoiDungs).WithMany(y => y.HoaDons).HasForeignKey(z => z.IDND);
        }
    }
}
