﻿// <auto-generated />
using System;
using Anthurium.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anthurium.API.Migrations
{
    [DbContext(typeof(AnthuriumContext))]
    partial class AnthuriumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Anthurium.Shared.Models.ClientInformation", b =>
                {
                    b.Property<int>("ClientInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("varchar(450) CHARACTER SET utf8mb4")
                        .HasMaxLength(450);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ClientInformationId");

                    b.ToTable("ClientInformations");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.JobOrder", b =>
                {
                    b.Property<int>("JobOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientInformationId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("varchar(450) CHARACTER SET utf8mb4")
                        .HasMaxLength(450);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("TimeEnded")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TimeStarted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("JobOrderId");

                    b.HasIndex("ClientInformationId");

                    b.ToTable("JobOrders");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.JobOrderDescriptionOfWork", b =>
                {
                    b.Property<int>("JobOrderDescriptionOfWorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("JobOrderId")
                        .HasColumnType("int");

                    b.Property<string>("JobOrderTypeOfWOrk")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("JobOrderDescriptionOfWorkId");

                    b.HasIndex("JobOrderId");

                    b.ToTable("JobOrderDescriptionOfWorks");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.JobOrder", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.ClientInformation", "ClientInformation")
                        .WithMany("JobOrder")
                        .HasForeignKey("ClientInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anthurium.Shared.Models.JobOrderDescriptionOfWork", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.JobOrder", "JobOrder")
                        .WithMany("JobOrderDescriptionOfWork")
                        .HasForeignKey("JobOrderId");
                });
#pragma warning restore 612, 618
        }
    }
}