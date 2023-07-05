﻿// <auto-generated />
using System;
using Assignment_C_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_C_4.Migrations
{
    [DbContext(typeof(DepDbContext))]
    [Migration("20230402210014_c2")]
    partial class c2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment_C_4.Models.ChucVu", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ThongTin")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ChucVu", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.GioHang", b =>
                {
                    b.Property<Guid>("IDND")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ThongTin")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDND");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDND")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDND");

                    b.HasIndex("IDSP");

                    b.ToTable("ChiTietGioHang", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.HoaDon", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDND")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime");

                    b.Property<int>("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDND");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<Guid>("IDHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDHD");

                    b.HasIndex("IDSP");

                    b.ToTable("ChiTietHoaDon", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.NguoiDung", b =>
                {
                    b.Property<Guid>("IDND")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IDCV")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SDT")
                        .HasColumnType("int");

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenND")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IDND");

                    b.HasIndex("IDCV");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.SanPham", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GiaBan")
                        .HasColumnType("int");

                    b.Property<int>("GiaNhap")
                        .HasColumnType("int");

                    b.Property<int>("KichCo")
                        .HasColumnType("int");

                    b.Property<string>("Mau")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SoLongTon")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("Assignment_C_4.Models.GioHang", b =>
                {
                    b.HasOne("Assignment_C_4.Models.NguoiDung", "NguoiDungs")
                        .WithOne("GioHangs")
                        .HasForeignKey("Assignment_C_4.Models.GioHang", "IDND")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDungs");
                });

            modelBuilder.Entity("Assignment_C_4.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("Assignment_C_4.Models.GioHang", "GioHangs")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IDND")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment_C_4.Models.SanPham", "SanPhams")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioHangs");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Assignment_C_4.Models.HoaDon", b =>
                {
                    b.HasOne("Assignment_C_4.Models.NguoiDung", "NguoiDungs")
                        .WithMany("HoaDons")
                        .HasForeignKey("IDND")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDungs");
                });

            modelBuilder.Entity("Assignment_C_4.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("Assignment_C_4.Models.HoaDon", "HoaDons")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IDHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment_C_4.Models.SanPham", "SanPhams")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDons");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Assignment_C_4.Models.NguoiDung", b =>
                {
                    b.HasOne("Assignment_C_4.Models.ChucVu", "ChucVus")
                        .WithMany("NguoiDungs")
                        .HasForeignKey("IDCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVus");
                });

            modelBuilder.Entity("Assignment_C_4.Models.ChucVu", b =>
                {
                    b.Navigation("NguoiDungs");
                });

            modelBuilder.Entity("Assignment_C_4.Models.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("Assignment_C_4.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("Assignment_C_4.Models.NguoiDung", b =>
                {
                    b.Navigation("GioHangs")
                        .IsRequired();

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Assignment_C_4.Models.SanPham", b =>
                {
                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });
#pragma warning restore 612, 618
        }
    }
}
