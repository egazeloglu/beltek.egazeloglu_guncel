﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using beltek.egazeloglu.Models;

#nullable disable

namespace beltek.egazeloglu.Migrations
{
    [DbContext(typeof(OgrDbContext))]
    [Migration("20240714201610_db_son_islem")]
    partial class db_son_islem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("beltek.egazeloglu.Models.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OgrenciId"), 1L, 1);

                    b.Property<string>("OgrenciAd")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("OgrenciNumara")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciSoyad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("OgrenciId");

                    b.HasIndex(new[] { "SinifId" }, "SinifId");

                    b.ToTable("tblOgrenciler", (string)null);
                });

            modelBuilder.Entity("beltek.egazeloglu.Models.Sinif", b =>
                {
                    b.Property<int>("SinifId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SinifId"), 1L, 1);

                    b.Property<int>("Kontenjan")
                        .HasColumnType("int");

                    b.Property<string>("SinifAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SinifId");

                    b.ToTable("tblSiniflar");
                });

            modelBuilder.Entity("beltek.egazeloglu.Models.Ogrenci", b =>
                {
                    b.HasOne("beltek.egazeloglu.Models.Sinif", "Sinif")
                        .WithMany("Ogrenciler")
                        .HasForeignKey("SinifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sinif");
                });

            modelBuilder.Entity("beltek.egazeloglu.Models.Sinif", b =>
                {
                    b.Navigation("Ogrenciler");
                });
#pragma warning restore 612, 618
        }
    }
}
