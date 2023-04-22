﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsData.Entities;

#nullable disable

namespace ProductsData.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230314185401_inital")]
    partial class inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductsData.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Country = "COLOMBIA",
                            Name = "Spoon",
                            Price = 9.9900000000000002,
                            Type = "Kitchen Utensils"
                        },
                        new
                        {
                            ProductId = 2,
                            Country = "CROATIA",
                            Name = "Bycicle",
                            Price = 4.9989999999999997,
                            Type = "Transportation"
                        },
                        new
                        {
                            ProductId = 3,
                            Country = "ITALY",
                            Name = "Necklace",
                            Price = 700.0,
                            Type = "Jewlery"
                        },
                        new
                        {
                            ProductId = 4,
                            Country = "FRANCE",
                            Name = "Water",
                            Price = 3.9900000000000002,
                            Type = "Consumables"
                        },
                        new
                        {
                            ProductId = 5,
                            Country = "ITALY",
                            Name = "Chair",
                            Price = 350.0,
                            Type = "Furniture"
                        });
                });

            modelBuilder.Entity("ProductsData.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Kitchen Utensils"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Transportation"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Jewlery"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Consumables"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Furniture"
                        });
                });

            modelBuilder.Entity("ProductsData.Entities.Product", b =>
                {
                    b.HasOne("ProductsData.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");

                    b.Navigation("ProductType");
                });
#pragma warning restore 612, 618
        }
    }
}