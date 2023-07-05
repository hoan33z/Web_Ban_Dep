using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_C_4.Configurations
{
    public class NguoiDungConfiguration : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.ToTable("NguoiDung");

            builder.HasKey(k => k.IDND);

            builder.Property(c => c.TenND).HasColumnType("nvarchar(50)");
            builder.Property(c => c.MatKhau).HasColumnType("nvarchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");

            builder.HasOne(x => x.ChucVus).WithMany(y => y.NguoiDungs).HasForeignKey(z => z.IDCV);
        }
    }
}
