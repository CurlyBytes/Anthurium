﻿// <auto-generated />
using System;
using Anthurium.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anthurium.API.Migrations
{
    [DbContext(typeof(AnthuriumContext))]
    [Migration("20210316133234_userAccountManagement")]
    partial class userAccountManagement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Anthurium.Shared.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientInformationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRecieve")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WarrantyDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AssetId");

                    b.HasIndex("ClientInformationId");

                    b.HasIndex("ItemId");

                    b.HasIndex("VendorId");

                    b.ToTable("Assets");
                });

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

                    b.Property<string>("ContactEmailAddress")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

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

                    b.HasKey("ClientInformationId");

                    b.ToTable("ClientInformations");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.DeliveryReceipt", b =>
                {
                    b.Property<int>("DeliveryReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientInformationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRecieve")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("JobQuotationId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.HasKey("DeliveryReceiptId");

                    b.HasIndex("ClientInformationId");

                    b.HasIndex("JobQuotationId");

                    b.ToTable("DeliveryReceipts");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.DeliveryReceiptDetails", b =>
                {
                    b.Property<int>("DeliveryReceiptDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeliveryReceiptId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DeliveryReceiptDetailsId");

                    b.HasIndex("DeliveryReceiptId");

                    b.HasIndex("ItemId");

                    b.ToTable("DeliveryReceiptDetailss");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ItemGroup")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Items");
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

                    b.Property<DateTime>("DateSchedule")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("JoboRderDescription")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<int>("RemainingHours")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Anthurium.Shared.Models.JobQuotation", b =>
                {
                    b.Property<int>("JobQuotationId")
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

                    b.Property<string>("ContactEmailAddress")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(400) CHARACTER SET utf8mb4")
                        .HasMaxLength(400);

                    b.Property<bool>("HasCustomerAlreadyAgreed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("OverallCost")
                        .HasColumnType("double");

                    b.HasKey("JobQuotationId");

                    b.HasIndex("ClientInformationId");

                    b.ToTable("JobQuotations");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.JobQuotationDetails", b =>
                {
                    b.Property<int>("JobQuotationDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsAlreadyPurchaseOrder")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<int>("JobQuotationId")
                        .HasColumnType("int");

                    b.Property<double>("MarginPrice")
                        .HasColumnType("double");

                    b.Property<double>("OriginalPrice")
                        .HasColumnType("double");

                    b.Property<string>("PurchaseOrderCode")
                        .HasColumnType("varchar(75) CHARACTER SET utf8mb4")
                        .HasMaxLength(75);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("double");

                    b.Property<double>("TotalCost")
                        .HasColumnType("double");

                    b.HasKey("JobQuotationDetailsId");

                    b.HasIndex("ItemId");

                    b.HasIndex("JobQuotationId");

                    b.ToTable("JobQuotationDetailss");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("VendorCode")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("VendorId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("WarehouseCode")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Anthurium.Shared.Models.Asset", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.ClientInformation", "ClientInformation")
                        .WithMany("Asset")
                        .HasForeignKey("ClientInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anthurium.Shared.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anthurium.Shared.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anthurium.Shared.Models.DeliveryReceipt", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.ClientInformation", "ClientInformation")
                        .WithMany("DeliveryReceipt")
                        .HasForeignKey("ClientInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anthurium.Shared.Models.JobQuotation", "JobQuotation")
                        .WithMany("DeliveryReceipt")
                        .HasForeignKey("JobQuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anthurium.Shared.Models.DeliveryReceiptDetails", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.DeliveryReceipt", "DeliveryReceipt")
                        .WithMany("DeliveryRecieptDetails")
                        .HasForeignKey("DeliveryReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anthurium.Shared.Models.Item", "Item")
                        .WithMany("DeliveryRecieptDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anthurium.Shared.Models.Item", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.Warehouse", "Warehouse")
                        .WithMany("Item")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Anthurium.Shared.Models.JobQuotation", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.ClientInformation", "ClientInformation")
                        .WithMany("JobQuotation")
                        .HasForeignKey("ClientInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anthurium.Shared.Models.JobQuotationDetails", b =>
                {
                    b.HasOne("Anthurium.Shared.Models.Item", "Item")
                        .WithMany("JobQuotationDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Anthurium.Shared.Models.JobQuotation", "JobQuotation")
                        .WithMany("JobQuotationDetails")
                        .HasForeignKey("JobQuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
