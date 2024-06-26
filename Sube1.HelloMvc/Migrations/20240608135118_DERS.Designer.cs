﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sube1.HelloMvc.Models;

#nullable disable

namespace Sube1.HelloMvc.Migrations
{
    [DbContext(typeof(OkulDbContext))]
    [Migration("20240608135118_DERS")]
    partial class DERS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sube1.HelloMvc.Models.Ders", b =>
                {
                    b.Property<int>("dersid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dersid"));

                    b.Property<string>("dersid")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("derskodu")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<int>("Kredi")
                        .HasColumnType("int");

                    b.HasKey("dersid");

                    b.ToTable("tblDersler", (string)null);
                });

            modelBuilder.Entity("Sube1.HelloMvc.Models.Ogrenci", b =>
                {
                    b.Property<int>("ogrid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ogrid"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("ogrid");

                    b.ToTable("tblOgrenciler", (string)null);
                });

            modelBuilder.Entity("Sube1.HelloMvc.Models.Relationships.OgrenciDers", b =>
                {
                    b.Property<int>("ogrid")
                        .HasColumnType("int");

                    b.Property<int>("dersid")
                        .HasColumnType("int");

                    b.HasKey("ogrid", "dersid");

                    b.HasIndex("dersid");

                    b.ToTable("tblOgrenciDersler", (string)null);
                });

            modelBuilder.Entity("Sube1.HelloMvc.Models.Relationships.OgrenciDers", b =>
                {
                    b.HasOne("Sube1.HelloMvc.Models.Ders", "Ders")
                        .WithMany("OgrenciDersler")
                        .HasForeignKey("dersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sube1.HelloMvc.Models.Ogrenci", "Ogrenci")
                        .WithMany("OgrenciDersler")
                        .HasForeignKey("ogrid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("Sube1.HelloMvc.Models.Ders", b =>
                {
                    b.Navigation("OgrenciDersler");
                });

            modelBuilder.Entity("Sube1.HelloMvc.Models.Ogrenci", b =>
                {
                    b.Navigation("OgrenciDersler");
                });
#pragma warning restore 612, 618
        }
    }
}
