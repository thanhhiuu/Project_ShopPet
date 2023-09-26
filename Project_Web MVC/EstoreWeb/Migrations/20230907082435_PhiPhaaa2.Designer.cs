﻿// <auto-generated />
using EstoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstoreWeb.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230907082435_PhiPhaaa2")]
    partial class PhiPhaaa2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EStoreWeb.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ChuThich")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            ChuThich = "Màu Xanh",
                            Gia = 190000.0,
                            ImageUrl = "VS.png",
                            Name = "iOphon 11 "
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ChuThich = "Màu Xanh",
                            Gia = 190000.0,
                            ImageUrl = "VS.png",
                            Name = "iOphon 11 "
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            ChuThich = "Màu Xanh",
                            Gia = 190000.0,
                            ImageUrl = "VS.png",
                            Name = "iOphon 11 "
                        });
                });

            modelBuilder.Entity("EstoreWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Điện thoại"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Laptop Gamming"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Phụ kiện"
                        });
                });

            modelBuilder.Entity("EStoreWeb.Models.Product", b =>
                {
                    b.HasOne("EstoreWeb.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
