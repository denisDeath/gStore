﻿// <auto-generated />
using gs.api.storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace gs.api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20180415160224_190206")]
    partial class _190206
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("gs.api.storage.model.Organization", b =>
                {
                    b.Property<long>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<string>("Inn")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("TradeMark")
                        .HasMaxLength(50);

                    b.Property<bool>("UseVat");

                    b.Property<long?>("UserId")
                        .IsRequired();

                    b.HasKey("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("gs.api.storage.model.resellers.dicts.Good", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUris");

                    b.Property<string>("Name");

                    b.Property<long?>("OrganizationId")
                        .IsRequired();

                    b.Property<string>("Unit");

                    b.Property<string>("VendorCode");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("gs.api.storage.model.resellers.dicts.GoodCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<long?>("OrganizationId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("GoodCategories");
                });

            modelBuilder.Entity("gs.api.storage.model.resellers.dicts.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<bool>("IsShop");

                    b.Property<string>("Name");

                    b.Property<long?>("OrganizationId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("gs.api.storage.model.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("gs.api.storage.model.Organization", b =>
                {
                    b.HasOne("gs.api.storage.model.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("gs.api.storage.model.resellers.dicts.Good", b =>
                {
                    b.HasOne("gs.api.storage.model.Organization", "Owner")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("gs.api.storage.model.resellers.dicts.GoodCategory", b =>
                {
                    b.HasOne("gs.api.storage.model.Organization", "Owner")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("gs.api.storage.model.resellers.dicts.Store", b =>
                {
                    b.HasOne("gs.api.storage.model.Organization", "Owner")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
