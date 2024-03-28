﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(LaptopParhizgerContext))]
    [Migration("20240328124454_InitToSurface")]
    partial class InitToSurface
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Addresses.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AddressDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfRecipient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Address", "dbo");
                });

            modelBuilder.Entity("Domain.Carts.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cart", "dbo");
                });

            modelBuilder.Entity("Domain.Carts.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("CartItem", "dbo");
                });

            modelBuilder.Entity("Domain.Category.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("Domain.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<long>("RequestPayId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Order", "dbo");
                });

            modelBuilder.Entity("Domain.Orders.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("OrderDetail", "dbo");
                });

            modelBuilder.Entity("Domain.Payment.PaymentSettings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PaymentSettings", "dbo");
                });

            modelBuilder.Entity("Domain.Payment.RequestPay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Authority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("RefId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RequestPay");
                });

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("AdminSuggestion")
                        .HasColumnType("bit");

                    b.Property<bool>("BigTable")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CartridgeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CopySpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DiscountedPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("FaxResolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Graphic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageNameFifth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageNameFourth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageNameSecond")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageNameThird")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncludedItems")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSpecial")
                        .HasColumnType("bit");

                    b.Property<string>("LapTopPorts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonthlyWorkCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaperInputCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaperSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("PrintResolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrinterMemory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintingTechnology")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessorSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProductNotExist")
                        .HasColumnType("bit");

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScannerDepth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScannerResolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Screen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("SpecialFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TypeOfGraphic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfRam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfStorage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Visit")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("nonOriginal")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Products", "dbo");
                });

            modelBuilder.Entity("Domain.Products.ProductComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ProductComment", "dbo");
                });

            modelBuilder.Entity("Domain.Sliders.Slider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("Domain.Sliders.SliderPosters", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ImageLocation")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("SliderPosters");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FullName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Domain.Addresses.Address", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumberForAddress", b1 =>
                        {
                            b1.Property<long>("AddressId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("AddressId");

                            b1.ToTable("Address", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("AddressId");
                        });

                    b.Navigation("PhoneNumberForAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Category.Category", b =>
                {
                    b.HasOne("Domain.Category.Category", null)
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<long>("CategoryId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Canonical")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Canonical")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Category.Category", b =>
                {
                    b.Navigation("Childs");
                });
#pragma warning restore 612, 618
        }
    }
}
