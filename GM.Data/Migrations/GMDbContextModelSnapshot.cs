﻿// <auto-generated />
using System;
using GM.Data.EFs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GM.Data.Migrations
{
    [DbContext(typeof(GMDbContext))]
    partial class GMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GM.Data.Entitis.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 628, DateTimeKind.Local).AddTicks(550));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 628, DateTimeKind.Local).AddTicks(965));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Challenge", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.CheckIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 629, DateTimeKind.Local).AddTicks(9662));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("NcId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Remain")
                        .HasColumnType("int");

                    b.Property<int>("Session")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("TimeOfDay")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 629, DateTimeKind.Local).AddTicks(9955));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("UserId");

                    b.ToTable("CheckIn", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(1716));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(2033));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.HealthInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(3993));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("NccId")
                        .HasColumnType("int");

                    b.Property<float>("Slush")
                        .HasColumnType("real");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("TimeOfDay")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(4289));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("NccId");

                    b.HasIndex("UserId");

                    b.ToTable("HealthInformation", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(8445));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("NcId")
                        .HasColumnType("int");

                    b.Property<int>("NccId")
                        .HasColumnType("int");

                    b.Property<int?>("PackageProductId")
                        .HasColumnType("int");

                    b.Property<int>("Remain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 630, DateTimeKind.Local).AddTicks(9007));

                    b.HasKey("Id");

                    b.HasIndex("NccId");

                    b.HasIndex("PackageProductId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 631, DateTimeKind.Local).AddTicks(5404));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 631, DateTimeKind.Local).AddTicks(7525));

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetail", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.NC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 633, DateTimeKind.Local).AddTicks(9251));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 634, DateTimeKind.Local).AddTicks(258));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NC", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.NCC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 632, DateTimeKind.Local).AddTicks(6515));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NcId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 632, DateTimeKind.Local).AddTicks(7982));

                    b.HasKey("Id");

                    b.HasIndex("NcId");

                    b.ToTable("NCC", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.PackageProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(1710));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(2386));

                    b.HasKey("Id");

                    b.ToTable("PackageProduct", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.PackageProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(6836));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("PackageProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 635, DateTimeKind.Local).AddTicks(7474));

                    b.HasKey("Id");

                    b.HasIndex("PackageProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("PackageProductDetail", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(312));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(654));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(3800));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(4326));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.UserPlayChallenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("ChallengerId")
                        .HasColumnType("int");

                    b.Property<int>("Complete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(6564));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("NccId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(6857));

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("NccId");

                    b.ToTable("UserPlayChallenge", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.UserPlayEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Complete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(8695));

                    b.Property<int?>("CreatorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("NccId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimeDelete")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 7, 5, 14, 54, 38, 636, DateTimeKind.Local).AddTicks(9042));

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("NccId");

                    b.ToTable("UserPlayEvent", (string)null);
                });

            modelBuilder.Entity("GM.Data.Entitis.Challenge", b =>
                {
                    b.HasOne("GM.Data.Entitis.User", "User")
                        .WithMany("Challenges")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GM.Data.Entitis.CheckIn", b =>
                {
                    b.HasOne("GM.Data.Entitis.Invoice", "Invoice")
                        .WithMany("CheckIns")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GM.Data.Entitis.User", null)
                        .WithMany("CheckIns")
                        .HasForeignKey("UserId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("GM.Data.Entitis.Event", b =>
                {
                    b.HasOne("GM.Data.Entitis.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GM.Data.Entitis.HealthInformation", b =>
                {
                    b.HasOne("GM.Data.Entitis.NCC", "Ncc")
                        .WithMany("HealthInformations")
                        .HasForeignKey("NccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GM.Data.Entitis.User", "User")
                        .WithMany("HealthInformations")
                        .HasForeignKey("UserId");

                    b.Navigation("Ncc");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GM.Data.Entitis.Invoice", b =>
                {
                    b.HasOne("GM.Data.Entitis.NCC", "Ncc")
                        .WithMany("Invoices")
                        .HasForeignKey("NccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GM.Data.Entitis.PackageProduct", "PackageProduct")
                        .WithMany("Invoices")
                        .HasForeignKey("PackageProductId");

                    b.Navigation("Ncc");

                    b.Navigation("PackageProduct");
                });

            modelBuilder.Entity("GM.Data.Entitis.InvoiceDetail", b =>
                {
                    b.HasOne("GM.Data.Entitis.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GM.Data.Entitis.Product", "Product")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GM.Data.Entitis.NC", b =>
                {
                    b.HasOne("GM.Data.Entitis.User", "User")
                        .WithMany("Ncs")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GM.Data.Entitis.NCC", b =>
                {
                    b.HasOne("GM.Data.Entitis.NC", "Nc")
                        .WithMany("Nccs")
                        .HasForeignKey("NcId");

                    b.Navigation("Nc");
                });

            modelBuilder.Entity("GM.Data.Entitis.PackageProductDetail", b =>
                {
                    b.HasOne("GM.Data.Entitis.PackageProduct", "PackageProduct")
                        .WithMany("PackageProductDetails")
                        .HasForeignKey("PackageProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GM.Data.Entitis.Product", "Product")
                        .WithMany("PackageProductDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PackageProduct");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GM.Data.Entitis.Product", b =>
                {
                    b.HasOne("GM.Data.Entitis.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GM.Data.Entitis.UserPlayChallenge", b =>
                {
                    b.HasOne("GM.Data.Entitis.Challenge", "Challenge")
                        .WithMany("UserPlayChallenges")
                        .HasForeignKey("ChallengeId");

                    b.HasOne("GM.Data.Entitis.NCC", "Ncc")
                        .WithMany()
                        .HasForeignKey("NccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Ncc");
                });

            modelBuilder.Entity("GM.Data.Entitis.UserPlayEvent", b =>
                {
                    b.HasOne("GM.Data.Entitis.Event", "Event")
                        .WithMany("UserPlayEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GM.Data.Entitis.NCC", "Ncc")
                        .WithMany()
                        .HasForeignKey("NccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Ncc");
                });

            modelBuilder.Entity("GM.Data.Entitis.Challenge", b =>
                {
                    b.Navigation("UserPlayChallenges");
                });

            modelBuilder.Entity("GM.Data.Entitis.Event", b =>
                {
                    b.Navigation("UserPlayEvents");
                });

            modelBuilder.Entity("GM.Data.Entitis.Invoice", b =>
                {
                    b.Navigation("CheckIns");

                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("GM.Data.Entitis.NC", b =>
                {
                    b.Navigation("Nccs");
                });

            modelBuilder.Entity("GM.Data.Entitis.NCC", b =>
                {
                    b.Navigation("HealthInformations");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("GM.Data.Entitis.PackageProduct", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("PackageProductDetails");
                });

            modelBuilder.Entity("GM.Data.Entitis.Product", b =>
                {
                    b.Navigation("InvoiceDetails");

                    b.Navigation("PackageProductDetails");
                });

            modelBuilder.Entity("GM.Data.Entitis.User", b =>
                {
                    b.Navigation("Challenges");

                    b.Navigation("CheckIns");

                    b.Navigation("Events");

                    b.Navigation("HealthInformations");

                    b.Navigation("Ncs");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
