using Anthurium.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<DeliveryReceiptDetails>().HasData(
                new DeliveryReceiptDetails
                {
                    DeliveryReceiptDetailsId = 1,
                    DeliveryReceiptId = 1,

                    ItemId = 1,
                    Quantity = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new DeliveryReceiptDetails
                {
                    DeliveryReceiptDetailsId = 2,
                    DeliveryReceiptId = 1,
                    ItemId = 2,
                    Quantity = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                      new DeliveryReceiptDetails
                      {
                          DeliveryReceiptDetailsId = 3,
                          DeliveryReceiptId = 1,
                          ItemId = 1,
                          Quantity = 1,
                          IsActive = true,
                          DateCreated = DateTime.UtcNow,
                          DateUpdated = DateTime.UtcNow
                      });
            modelBuilder.Entity<Vendor>().HasData(new Vendor
            {
                VendorId = 1,
                VendorName = "Microsoft",
                VendorCode = "MS",
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
                new Vendor
                {
                    VendorId = 2,
                    VendorName = "Dell",
                    VendorCode = "DL1",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                });
            modelBuilder.Entity<Asset>().HasData(new Asset
            {
                AssetId = 1,
                ClientInformationId = 1,
                ItemId = 1,
                VendorId = 1,
                SerialNumber = "333-222-3333-xxx-11",
                WarrantyDate = DateTime.UtcNow.AddMonths(20),
                DateRecieve = DateTime.UtcNow.AddDays(-20),
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
                new Asset
                {
                    AssetId = 2,
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "111-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(30),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset
               {
                   AssetId = 3,
                   ClientInformationId = 1,
                   ItemId = 1,
                   SerialNumber = "444-222-3333-xxx-11",
                   WarrantyDate = DateTime.UtcNow.AddMonths(24),
                   DateRecieve = DateTime.UtcNow.AddDays(-20),
                   IsActive = true,
                   DateCreated = DateTime.UtcNow,
                   DateUpdated = DateTime.UtcNow
               },
                new Asset
                {
                    AssetId = 4,
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "555-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }, new Asset
                {
                    AssetId = 5,
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "666-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(32),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset
                {
                    AssetId = 6,
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "777-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset
               {
                   AssetId = 7,
                   ClientInformationId = 1,
                   ItemId = 1,
                   VendorId = 2,
                   SerialNumber = "888-222-3333-xxx-11",
                   WarrantyDate = DateTime.UtcNow.AddMonths(14),
                   DateRecieve = DateTime.UtcNow.AddDays(-20),
                   IsActive = true,
                   DateCreated = DateTime.UtcNow,
                   DateUpdated = DateTime.UtcNow
               },
                new Asset
                {
                    AssetId = 8,
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "999-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                       new Asset
                       {
                           AssetId = 9,
                           ClientInformationId = 1,
                           ItemId = 2,
                           VendorId = 2,
                           SerialNumber = "1212-222-3333-xxx-11",
                           WarrantyDate = DateTime.UtcNow.AddMonths(15),
                           DateRecieve = DateTime.UtcNow.AddDays(-20),
                           IsActive = true,
                           DateCreated = DateTime.UtcNow,
                           DateUpdated = DateTime.UtcNow
                       },
                new Asset
                {
                    AssetId = 10,
                    ClientInformationId = 1,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "1111-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset
               {
                   AssetId = 11,
                   ClientInformationId = 1,
                   ItemId = 2,
                   VendorId = 2,
                   SerialNumber = "1313-222-3333-xxx-11",
                   WarrantyDate = DateTime.UtcNow.AddMonths(12),
                   DateRecieve = DateTime.UtcNow.AddDays(-20),
                   IsActive = true,
                   DateCreated = DateTime.UtcNow,
                   DateUpdated = DateTime.UtcNow
               },
                new Asset
                {
                    AssetId = 12,
                    ClientInformationId = 1,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "1414-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(24),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                     new Asset
                     {
                         AssetId = 13,
                         ClientInformationId = 2,
                         ItemId = 1,
                         VendorId = 2,
                         SerialNumber = "1515-222-3333-xxx-11",
                         WarrantyDate = DateTime.UtcNow.AddMonths(23),
                         DateRecieve = DateTime.UtcNow.AddDays(-20),
                         IsActive = true,
                         DateCreated = DateTime.UtcNow,
                         DateUpdated = DateTime.UtcNow
                     },
                new Asset
                {
                    AssetId = 14,
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "1616-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(24),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset
               {
                   AssetId = 15,
                   ClientInformationId = 2,
                   ItemId = 1,
                   VendorId = 2,
                   SerialNumber = "1717-222-3333-xxx-11",
                   WarrantyDate = DateTime.UtcNow.AddMonths(44),
                   DateRecieve = DateTime.UtcNow.AddDays(-20),
                   IsActive = true,
                   DateCreated = DateTime.UtcNow,
                   DateUpdated = DateTime.UtcNow
               },
                new Asset
                {
                    AssetId = 16,
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "1818-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }, new Asset
                {
                    AssetId = 17,
                    ClientInformationId = 2,
                    ItemId = 1,
                    SerialNumber = "1919-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset
                {
                    AssetId = 18,
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "2020-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(12),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset
               {
                   AssetId = 19,
                   ClientInformationId = 2,
                   ItemId = 1,
                   VendorId = 2,
                   SerialNumber = "2121-222-3333-xxx-11",
                   WarrantyDate = DateTime.UtcNow.AddMonths(14),
                   DateRecieve = DateTime.UtcNow.AddDays(-20),
                   IsActive = true,
                   DateCreated = DateTime.UtcNow,
                   DateUpdated = DateTime.UtcNow
               },
                new Asset
                {
                    AssetId = 20,
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "2222-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(32),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                       new Asset
                       {
                           AssetId = 21,
                           ClientInformationId = 2,
                           ItemId = 2,
                           VendorId = 2,
                           SerialNumber = "2323-222-3333-xxx-11",
                           WarrantyDate = DateTime.UtcNow.AddMonths(20),
                           DateRecieve = DateTime.UtcNow.AddDays(-20),
                           IsActive = true,
                           DateCreated = DateTime.UtcNow,
                           DateUpdated = DateTime.UtcNow
                       },
                new Asset
                {
                    AssetId = 22,
                    ClientInformationId = 2,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "2424-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(20),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset
               {
                   AssetId = 23,
                   ClientInformationId = 2,
                   ItemId = 2,
                   VendorId = 2,
                   SerialNumber = "2525-222-3333-xxx-11",
                   WarrantyDate = DateTime.UtcNow.AddMonths(20),
                   DateRecieve = DateTime.UtcNow.AddDays(-20),
                   IsActive = true,
                   DateCreated = DateTime.UtcNow,
                   DateUpdated = DateTime.UtcNow
               },
                new Asset
                {
                    AssetId = 24,
                    ClientInformationId = 2,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "2626-222-3333-xxx-11",
                    WarrantyDate = DateTime.UtcNow.AddMonths(20),
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                });
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemId = 1,
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Razer x123",
                    WarehouseId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Item
                {
                    ItemId = 2,
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z31",
                    WarehouseId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                            new Item
                            {
                                ItemId = 3,
                                ItemType = "Mouse",
                                ItemGroup = "Computer Set",
                                ItemCode = "m-cs-1",
                                ItemName = "Razer x33",

                                WarehouseId = 1,

                                DateCreated = DateTime.UtcNow,
                                DateUpdated = DateTime.UtcNow
                            },
                new Item
                {
                    ItemId = 4,
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z524",
                    WarehouseId = 1,

                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                     new Item
                     {
                         ItemId = 5,
                         ItemType = "Mouse",
                         ItemGroup = "Computer Set",
                         ItemCode = "m-cs-1",
                         ItemName = "Razer x123",

                         WarehouseId = 2,

                         IsActive = true,
                         DateCreated = DateTime.UtcNow,
                         DateUpdated = DateTime.UtcNow
                     },
                new Item
                {
                    ItemId = 6,
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z31",
                    WarehouseId = 2,

                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                            new Item
                            {
                                ItemId = 7,
                                ItemType = "Mouse",
                                ItemGroup = "Computer Set",
                                ItemCode = "m-cs-1",
                                ItemName = "Razer x33",

                                WarehouseId = 2,
                                IsActive = true,
                                DateCreated = DateTime.UtcNow,
                                DateUpdated = DateTime.UtcNow
                            },
                new Item
                {
                    ItemId = 8,
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z524",

                    WarehouseId = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                });
            modelBuilder.Entity<ClientInformation>().HasData(new ClientInformation
            {
                ClientInformationId = 1,
                CompanyName = "AMA",
                CompanyAddress = "eduardo aboitiz street",
                ContactEmailAddress = "test@rrr.com",
                ContactPerson = "Tao yang",
                ContactNumber = "1134455",
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
                new ClientInformation
                {
                    ClientInformationId = 2,
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ContactEmailAddress = "bbb@bb.com",
                    ContactPerson = "bob uy",
                    ContactNumber = "09866191",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation
                {
                    ClientInformationId = 3,
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    ContactEmailAddress = "CC@cc.com",
                    ContactPerson = "sicnarf noyag",
                    ContactNumber = "1134455",

                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
);
            modelBuilder.Entity<JobOrder>().HasData(new JobOrder
            {

                JobOrderId = 1,
                CompanyName = "AMA",
                CompanyAddress = "eduardo aboitiz street",
                ClientInformationId = 1,
                ContactPerson = "amaers",
                ContactNumber = "+0639207082",
                DateSchedule = DateTime.UtcNow.AddHours(55),
                JoboRderDescription = "another work heree",
                RemainingHours = 2,
                TimeStarted = DateTime.UtcNow,
                TimeEnded = DateTime.UtcNow,
                TotalHours = 2,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
                new JobOrder
                {
                    JobOrderId = 2,
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    DateSchedule = DateTime.UtcNow.AddHours(52),
                    JoboRderDescription = "this a manual work here",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(12),
                    TimeEnded = DateTime.UtcNow.AddHours(35),
                    TotalHours = 31,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobOrder
                {
                    JobOrderId = 3,
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    DateSchedule = DateTime.UtcNow.AddHours(62),
                    JoboRderDescription = "this a manual work here",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(2),
                    TotalHours = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobOrder
                {
                    JobOrderId = 4,
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ClientInformationId = 2,
                    ContactPerson = "Cocoy",
                    ContactNumber = "4177214",
                    DateSchedule = DateTime.UtcNow.AddHours(742),
                    JoboRderDescription = "lazy work",
                    RemainingHours = 1,
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(2),
                    TotalHours = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobOrder
                {
                    JobOrderId = 5,
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ClientInformationId = 2,
                    ContactPerson = "Cacay",
                    ContactNumber = "4177214",
                    DateSchedule = DateTime.UtcNow.AddHours(203),
                    JoboRderDescription = "job order",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(11),
                    TimeEnded = DateTime.UtcNow.AddHours(42),
                    TotalHours = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobOrder
                {
                    JobOrderId = 6,
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    ClientInformationId = 3,
                    ContactPerson = "Trump",
                    ContactNumber = "21141",
                    DateSchedule = DateTime.UtcNow.AddHours(332),
                    JoboRderDescription = "test work",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(12),
                    TotalHours = 8,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
);
            modelBuilder.Entity<JobQuotation>().HasData(new JobQuotation
            {

                JobQuotationId = 1,
                OverallCost = 100.0,
                Description = "Sample Job Quotation From AMA",
                ClientInformationId = 1,
                ContactPerson = "amaers",
                ContactNumber = "+0639207082",
                CompanyName = "AMA",
                CompanyAddress = "eduardo aboitiz street",
                ContactEmailAddress = "tset@tset.com",
                IsActive = true,
                HasCustomerAlreadyAgreed = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
                new JobQuotation
                {
                    JobQuotationId = 2,
                    OverallCost = 200.0,
                    Description = "Sample Job Quotation From AMA",
                    ClientInformationId = 1,
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    ContactEmailAddress = "aaa@tset.com",
                    IsActive = true,
                    HasCustomerAlreadyAgreed = false,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobQuotation
                {
                    JobQuotationId = 3,
                    OverallCost = 300.0,
                    Description = "CurlyBytes JobQuote",
                    ClientInformationId = 2,
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ContactPerson = "Cocoy",
                    ContactNumber = "4177214",
                    ContactEmailAddress = "fff@tset.com",
                    IsActive = true,
                    HasCustomerAlreadyAgreed = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                });
            modelBuilder.Entity<JobQuotationDetails>().HasData(new JobQuotationDetails
            {
                JobQuotationDetailsId = 1,
                ItemId = 1,
                Quantity = 2,
                OriginalPrice = 20,
                MarginPrice = 100,
                SellingPrice = 120,
                ItemName = "Razer x123",
                TotalCost = 240,
                JobQuotationId = 1,
                IsActive = true,
                IsAlreadyPurchaseOrder = true,
                PurchaseOrderCode = "ffff-111",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
                 new JobQuotationDetails
                 {
                     JobQuotationDetailsId = 2,
                     ItemId = 2,
                     Quantity = 1,
                     OriginalPrice = 200,
                     MarginPrice = 30,
                     SellingPrice = 230,
                     ItemName = "Jedel z31",
                     TotalCost = 230,
                     JobQuotationId = 1,
                     IsActive = true,
                     IsAlreadyPurchaseOrder = true,
                     PurchaseOrderCode = "ffff-111",
                     DateCreated = DateTime.UtcNow,
                     DateUpdated = DateTime.UtcNow
                 },
                  new JobQuotationDetails
                  {
                      JobQuotationDetailsId = 3,
                      ItemId = 3,
                      Quantity = 3,
                      OriginalPrice = 100,
                      MarginPrice = 20,
                      SellingPrice = 120,
                      ItemName = "Razer x33",
                      TotalCost = 360,
                      JobQuotationId = 1,
                      IsActive = true,
                      IsAlreadyPurchaseOrder = false,
                      PurchaseOrderCode = "",
                      DateCreated = DateTime.UtcNow,
                      DateUpdated = DateTime.UtcNow
                  },
                 new JobQuotationDetails
                 {
                     JobQuotationDetailsId = 4,
                     ItemId = 4,
                     Quantity = 3,
                     OriginalPrice = 200,
                     MarginPrice = 30,
                     SellingPrice = 230,
                     ItemName = "Jedel z524",
                     TotalCost = 390,
                     JobQuotationId = 2,
                     IsActive = true,
                     IsAlreadyPurchaseOrder = true,
                     PurchaseOrderCode = "ffff-111",
                     DateCreated = DateTime.UtcNow,
                     DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails
                 {
                     JobQuotationDetailsId = 5,
                     ItemId = 5,
                     Quantity = 2,
                     OriginalPrice = 200,
                     MarginPrice = 30,
                     SellingPrice = 230,
                     ItemName = "Razer x123",
                     TotalCost = 460,
                     JobQuotationId = 2,
                     IsActive = true,
                     IsAlreadyPurchaseOrder = false,
                     PurchaseOrderCode = "",
                     DateCreated = DateTime.UtcNow,
                     DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails
                 {
                     JobQuotationDetailsId = 6,
                     ItemId = 6,
                     Quantity = 1,
                     OriginalPrice = 100,
                     MarginPrice = 20,
                     SellingPrice = 120,
                     ItemName = "Razer x33",
                     TotalCost = 120,
                     JobQuotationId = 3,
                     IsActive = true,
                     IsAlreadyPurchaseOrder = false,
                     PurchaseOrderCode = "",
                     DateCreated = DateTime.UtcNow,
                     DateUpdated = DateTime.UtcNow
                 });
        }
    }
}
