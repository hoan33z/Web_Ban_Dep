using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("ChucVu");
            builder.HasKey(k => k.ID);

            builder.Property(c => c.TenChucVu).HasColumnType("nvarchar(20)");
            builder.Property(c => c.ThongTin).HasColumnType("nvarchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
