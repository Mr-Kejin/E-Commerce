﻿// <auto-generated />
using GoodWillStones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodWillStones.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230504163552_seedcategrytable")]
    partial class seedcategrytable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
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
                        .HasColumnType("nvarchar(max)");

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
#pragma warning restore 612, 618
        }
    }
}
