﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monolith.DAL;

namespace Monolith.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190507133840_Main")]
    partial class Main
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monolith.DAL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Monolith.DAL.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountPaid");

                    b.Property<double>("BasePrice");

                    b.Property<double>("ChangeGiven");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsFinished");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<double>("PriceWithVat");

                    b.Property<int?>("VatRateId");

                    b.HasKey("Id");

                    b.HasIndex("VatRateId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Monolith.DAL.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int?>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("OrderProductLink");
                });

            modelBuilder.Entity("Monolith.DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("DelFlag");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Monolith.DAL.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CostMultiplier");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<double>("FillSize");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Monolith.DAL.Models.VatRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<double>("Multiplier");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("VatRates");
                });

            modelBuilder.Entity("Monolith.DAL.Models.Order", b =>
                {
                    b.HasOne("Monolith.DAL.Models.VatRate", "VatRate")
                        .WithMany()
                        .HasForeignKey("VatRateId");
                });

            modelBuilder.Entity("Monolith.DAL.Models.OrderProduct", b =>
                {
                    b.HasOne("Monolith.DAL.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Monolith.DAL.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Monolith.DAL.Models.Size", "Size")
                        .WithMany("OrderProducts")
                        .HasForeignKey("SizeId");
                });

            modelBuilder.Entity("Monolith.DAL.Models.Product", b =>
                {
                    b.HasOne("Monolith.DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
