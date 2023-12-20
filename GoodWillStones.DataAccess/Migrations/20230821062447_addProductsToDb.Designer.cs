﻿// <auto-generated />
using GoodWillStones.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodWillStones.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230821062447_addProductsToDb")]
    partial class addProductsToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoodWillStones.Models.Category", b =>
                {
                    b.Property<int>("lCategory_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lCategory_ID"));

                    b.Property<string>("sDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("sDisplayOrder")
                        .HasColumnType("int");

                    b.HasKey("lCategory_ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            lCategory_ID = 1,
                            sDescription = "Brick",
                            sDisplayOrder = 1
                        },
                        new
                        {
                            lCategory_ID = 2,
                            sDescription = "M-Sand",
                            sDisplayOrder = 2
                        },
                        new
                        {
                            lCategory_ID = 3,
                            sDescription = "P-Sand",
                            sDisplayOrder = 3
                        },
                        new
                        {
                            lCategory_ID = 4,
                            sDescription = "Blue-Metal",
                            sDisplayOrder = 4
                        });
                });

            modelBuilder.Entity("GoodWillStones.Models.Products", b =>
                {
                    b.Property<int>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_ID"));

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("ListPrice100")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("sDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Product_ID = 1,
                            ListPrice = 100.0,
                            ListPrice100 = 80.0,
                            Price = 95.0,
                            Price50 = 90.0,
                            sDescription = "It is a type of sand ",
                            sProductName = "M-sand"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}