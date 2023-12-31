﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SqlDataAccess.Context;

#nullable disable

namespace SqlDataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("data")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SqlDataAccess.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities", "data");
                });

            modelBuilder.Entity("SqlDataAccess.Models.ExternalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Humidity")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Temperature")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("ExternalDatas", "data");
                });

            modelBuilder.Entity("SqlDataAccess.Models.InternalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Humidity")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Temperature")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("InternalDatas", "data");
                });

            modelBuilder.Entity("SqlDataAccess.Models.Month", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Months", "data");
                });

            modelBuilder.Entity("SqlDataAccess.Models.MonthExternalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExternalDataId")
                        .HasColumnType("int");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MonthId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalDataId");

                    b.HasIndex("MonthId");

                    b.ToTable("MonthExternalDatas", "data");
                });

            modelBuilder.Entity("SqlDataAccess.Models.MonthInternalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InternalDataId")
                        .HasColumnType("int");

                    b.Property<int>("MonthId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InternalDataId");

                    b.HasIndex("MonthId");

                    b.ToTable("MonthInternalDatas", "data");
                });

            modelBuilder.Entity("SqlDataAccess.Models.Month", b =>
                {
                    b.HasOne("SqlDataAccess.Models.City", "City")
                        .WithMany("Months")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("SqlDataAccess.Models.MonthExternalData", b =>
                {
                    b.HasOne("SqlDataAccess.Models.ExternalData", "ExternalData")
                        .WithMany("MonthExternalDatas")
                        .HasForeignKey("ExternalDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SqlDataAccess.Models.Month", "Month")
                        .WithMany("MonthExternalDatas")
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExternalData");

                    b.Navigation("Month");
                });

            modelBuilder.Entity("SqlDataAccess.Models.MonthInternalData", b =>
                {
                    b.HasOne("SqlDataAccess.Models.InternalData", "InternalData")
                        .WithMany("MonthInternalDatas")
                        .HasForeignKey("InternalDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SqlDataAccess.Models.Month", "Month")
                        .WithMany("MonthInternalDatas")
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InternalData");

                    b.Navigation("Month");
                });

            modelBuilder.Entity("SqlDataAccess.Models.City", b =>
                {
                    b.Navigation("Months");
                });

            modelBuilder.Entity("SqlDataAccess.Models.ExternalData", b =>
                {
                    b.Navigation("MonthExternalDatas");
                });

            modelBuilder.Entity("SqlDataAccess.Models.InternalData", b =>
                {
                    b.Navigation("MonthInternalDatas");
                });

            modelBuilder.Entity("SqlDataAccess.Models.Month", b =>
                {
                    b.Navigation("MonthExternalDatas");

                    b.Navigation("MonthInternalDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
