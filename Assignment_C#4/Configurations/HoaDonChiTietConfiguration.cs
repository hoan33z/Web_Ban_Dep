using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("ChiTietHoaDon");

            builder.Property(c => c.SoLuong).HasColumnType("int");
            builder.Property(c => c.Gia).HasColumnType("int");

            builder.HasOne(x => x.HoaDons).WithMany(y => y.HoaDonChiTiets).HasForeignKey(z => z.IDHD);
            builder.HasOne(x => x.SanPhams).WithMany(y => y.HoaDonChiTiets).HasForeignKey(z => z.IDSP);
        }
    }
}
