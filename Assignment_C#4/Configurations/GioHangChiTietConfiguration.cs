using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("ChiTietGioHang");

            builder.Property(c => c.SoLuong).HasColumnType("int");

            builder.HasOne(x => x.GioHangs).WithMany(y => y.GioHangChiTiets).HasForeignKey(z => z.IDND);
            builder.HasOne(x => x.SanPhams).WithMany(y => y.GioHangChiTiets).HasForeignKey(z => z.IDSP);

        }
    }
}
