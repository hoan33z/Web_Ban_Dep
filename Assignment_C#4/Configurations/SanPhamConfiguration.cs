using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(k => k.ID);
            builder.Property(c => c.TenSP).HasColumnType("nvarchar(50)");
            builder.Property(c => c.Mau).HasColumnType("nvarchar(20)");
            builder.Property(c => c.KichCo).HasColumnType("int");
            builder.Property(c => c.GiaBan).HasColumnType("int");
            builder.Property(c => c.SoLongTon).HasColumnType("int");
            builder.Property(c => c.TrangThai).HasColumnType("int");
            builder.Property(c => c.GiaBan).HasColumnType("int");
            builder.Property(c => c.HinhAnh).HasColumnType("nvarchar(100)");
        }
    }
}
