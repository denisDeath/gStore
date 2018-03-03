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
    [Migration("20180303153510_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("gs.api.storage.model.IeOrganization", b =>
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
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("UserId")
                        .IsRequired();

                    b.HasKey("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("IeOrganizations");
                });

            modelBuilder.Entity("gs.api.storage.model.LtdOrganization", b =>
                {
                    b.Property<long>("OrganizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<string>("Inn")
                        .HasMaxLength(50);

                    b.Property<string>("Kpp");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("ShortName");

                    b.Property<string>("TradeMark")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("UserId")
                        .IsRequired();

                    b.HasKey("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("LtdOrganizations");
                });

            modelBuilder.Entity("gs.api.storage.model.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Token");

                    b.Property<DateTime?>("TokenExpireDate");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("gs.api.storage.model.IeOrganization", b =>
                {
                    b.HasOne("gs.api.storage.model.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("gs.api.storage.model.LtdOrganization", b =>
                {
                    b.HasOne("gs.api.storage.model.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
