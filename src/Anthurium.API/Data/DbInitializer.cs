﻿using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(AnthuriumContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Contacts.
            if (context.ClientInformations.Any())
            {
                return;   // DB has been seeded
            }

            var warehouses = new Warehouse[]
            {
                new Warehouse {
                    WarehouseName = "The warehouse 1",
                    WarehouseCode = "t-w-1",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Warehouse {
                    WarehouseName = "The warehouse 2",
                    WarehouseCode = "t-w-2",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }

            };

            var vendors = new Vendor[]
            {
                new Vendor {
                    VendorName = "Microsoft",
                    VendorCode = "MS",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Vendor {
                    VendorName = "Dell",
                    VendorCode = "DL1",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }

            };

            var items = new Item[]
            {
                new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Razer x123",
                    Margin = 20,
                    Price = 100,
                    VendorId = 1,
                    WarehouseId = 1,
                    IsLocalMaterial = false,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z31",
                    Margin = 30,
                    Price = 200,
                    VendorId = 2,
                    WarehouseId = 1,
                    IsLocalMaterial = true,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                            new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Razer x33",
                    Margin = 20,
                    Price = 100,
                    VendorId = 1,
                    WarehouseId = 1,
                    IsLocalMaterial = false,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z524",
                    Margin = 30,
                    Price = 200,
                    VendorId = 2,
                    WarehouseId = 1,
                    IsLocalMaterial = true,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                     new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Razer x123",
                    Margin = 20,
                    Price = 100,
                    VendorId = 1,
                    WarehouseId = 2,
                    IsLocalMaterial = false,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z31",
                    Margin = 30,
                    Price = 200,
                    VendorId = 2,
                    WarehouseId = 2,
                    IsLocalMaterial = true,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                            new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Razer x33",
                    Margin = 20,
                    Price = 100,
                    VendorId = 1,
                    WarehouseId = 2,
                    IsLocalMaterial = false,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Item {
                    ItemType = "Mouse",
                    ItemGroup = "Computer Set",
                    ItemCode = "m-cs-1",
                    ItemName = "Jedel z524",
                    Margin = 30,
                    Price = 200,
                    VendorId = 2,
                    WarehouseId = 2,
                    IsLocalMaterial = true,
                    WarrantyDate = DateTime.UtcNow.AddYears(2),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }

            };

            var clientInformations = new ClientInformation[]
            {
                new ClientInformation { 
                    CompanyName = "AMA",  
                    CompanyAddress = "eduardo aboitiz street",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation { 
                    CompanyName = "CurlyBytes",  
                    CompanyAddress = "107 v. raman st. calamba cc",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation {
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    }

            };
            
            var jobOrders = new JobOrder[]
            {
                new JobOrder { 
                    CompanyName = "AMA",  
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    DateSchedule =DateTime.UtcNow.AddHours(55),
                    JoboRderDescription = "another work heree",
                    RemainingHours = 2,
                    TimeStarted = DateTime.UtcNow,
                    TimeEnded = DateTime.UtcNow,
                    TotalHours = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    DateSchedule =DateTime.UtcNow.AddHours(52),
                    JoboRderDescription = "this a manual work here",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(12),
                    TimeEnded = DateTime.UtcNow.AddHours(35),
                    TotalHours = 31,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    DateSchedule =DateTime.UtcNow.AddHours(62),
                    JoboRderDescription = "this a manual work here",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(2),
                    TotalHours = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ClientInformationId = 2,
                    ContactPerson = "Cocoy",
                    ContactNumber = "4177214",
                    DateSchedule =DateTime.UtcNow.AddHours(742),
                    JoboRderDescription = "lazy work",
                    RemainingHours = 1,
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(2),
                    TotalHours = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ClientInformationId = 2,
                    ContactPerson = "Cacay",
                    ContactNumber = "4177214",
                    DateSchedule =DateTime.UtcNow.AddHours(203),
                    JoboRderDescription = "job order",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(11),
                    TimeEnded = DateTime.UtcNow.AddHours(42),
                    TotalHours = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    ClientInformationId = 3,
                    ContactPerson = "Trump",
                    ContactNumber = "21141",
                    DateSchedule =DateTime.UtcNow.AddHours(332),
                    JoboRderDescription = "test work",
                    RemainingHours = 4,
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(12),
                    TotalHours = 8,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    }

            };
            var jobQuotation = new JobQuotation[] { 
                new JobQuotation {
                    OverallCost = 100.0,
                    Description = "Sample Job Quotation From AMA",
                    ClientInformationId = 1,
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobQuotation {
                    OverallCost = 200.0,
                    Description = "Sample Job Quotation From AMA",
                    ClientInformationId = 1,
                    CompanyName = "AMA",
                    CompanyAddress = "eduardo aboitiz street",
                    ContactPerson = "amaers",
                    ContactNumber = "+0639207082",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new JobQuotation {
                    OverallCost = 300.0,
                    Description = "CurlyBytes JobQuote",
                    ClientInformationId = 2,
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ContactPerson = "Cocoy",
                    ContactNumber = "4177214",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
            };

            var jobQuotationDetails = new JobQuotationDetails[] {
                 new JobQuotationDetails{ 
                    Quantity = 2,
                    Cost = 12.5,
                    ItemName = "cable",
                    TotalCost = 25,
                    JobQuotationId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    Quantity = 1,
                    Cost = 75,
                    ItemName = "wire",
                    TotalCost = 75,
                    JobQuotationId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                  new JobQuotationDetails{
                    Quantity = 3,
                    Cost = 50,
                    ItemName = "mouse",
                    TotalCost = 150,
                    JobQuotationId = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    Quantity = 2,
                    Cost = 12.5,
                    ItemName = "cable",
                    TotalCost = 25,
                    JobQuotationId = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    Quantity = 2,
                    Cost = 12.5,
                    ItemName = "cable",
                    TotalCost = 25,
                    JobQuotationId = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    Quantity = 3,
                    Cost = 50,
                    ItemName = "mouse",
                    TotalCost = 150,
                    JobQuotationId = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    Quantity = 1,
                    Cost = 100,
                    ItemName = "monitor",
                    TotalCost = 100,
                    JobQuotationId = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
            };
            context.Warehouses.AddRange(warehouses);
            context.Vendors.AddRange(vendors);
            context.Items.AddRange(items);
            context.ClientInformations.AddRange(clientInformations);
            context.JobOrders.AddRange(jobOrders);
            context.JobQuotations.AddRange(jobQuotation);
            context.JobQuotationDetailss.AddRange(jobQuotationDetails);
            context.SaveChanges();
        }
    }
}
