﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Migrations
{
    [DbContext(typeof(AnthuriumContext))]
    partial class AnthuriumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("WebApi.Models.ClientInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("JobOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobOrderId");

                    b.ToTable("ClientInformations");
                });

            modelBuilder.Entity("WebApi.Models.JobOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("JobOrderDescriptionOfWorkId")
                        .HasColumnType("int");

                    b.Property<string>("TimeEnded")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeStarted")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobOrderDescriptionOfWorkId");

                    b.ToTable("JobOrders");
                });

            modelBuilder.Entity("WebApi.Models.JobOrderDescriptionOfWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobOrderTypeOfWOrk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobOrderDescriptionOfWorks");
                });

            modelBuilder.Entity("WebApi.Models.ClientInformation", b =>
                {
                    b.HasOne("WebApi.Models.JobOrder", "JobOrder")
                        .WithMany("ClientInformations")
                        .HasForeignKey("JobOrderId");

                    b.Navigation("JobOrder");
                });

            modelBuilder.Entity("WebApi.Models.JobOrder", b =>
                {
                    b.HasOne("WebApi.Models.JobOrderDescriptionOfWork", "JobOrderDescriptionOfWork")
                        .WithMany("JobOrders")
                        .HasForeignKey("JobOrderDescriptionOfWorkId");

                    b.Navigation("JobOrderDescriptionOfWork");
                });

            modelBuilder.Entity("WebApi.Models.JobOrder", b =>
                {
                    b.Navigation("ClientInformations");
                });

            modelBuilder.Entity("WebApi.Models.JobOrderDescriptionOfWork", b =>
                {
                    b.Navigation("JobOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
