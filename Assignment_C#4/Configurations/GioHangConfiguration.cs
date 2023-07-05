using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang");

            builder.HasKey(k => k.IDND);
            builder.Property(c => c.ThongTin).HasColumnType("nvarchar(100)");

            builder.HasOne(c => c.NguoiDungs).WithOne(c => c.GioHangs).HasForeignKey<GioHang>(c => c.IDND);
        }
    }
}
