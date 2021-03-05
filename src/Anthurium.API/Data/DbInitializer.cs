using Anthurium.Shared.Models;
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

            var deliveryReceiptDetails = new DeliveryReceiptDetails[]
            {
                new DeliveryReceiptDetails {
                    DeliveryReceiptId = 1,
                    ItemId = 1,
                    Quantity = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new DeliveryReceiptDetails {
                    DeliveryReceiptId = 1,
                    ItemId = 2,
                    Quantity = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                      new DeliveryReceiptDetails {
                    DeliveryReceiptId = 2,
                    ItemId = 1,
                    Quantity = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new DeliveryReceiptDetails {
                    DeliveryReceiptId = 2,
                    ItemId = 2,
                    Quantity = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }

            };

            var deliveryReceipts = new DeliveryReceipt[]
            {
                new DeliveryReceipt {
                    ClientInformationId = 1,
                    JobQuotationId = 1,
                    Remarks ="All mouse",
                    DateRecieve = DateTime.UtcNow.AddDays(-25),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new DeliveryReceipt {
                    ClientInformationId = 1,
                    JobQuotationId = 1,
                    Remarks ="All keyboard",
                    DateRecieve = DateTime.UtcNow.AddDays(-15),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new DeliveryReceipt {
                    ClientInformationId = 2,
                    JobQuotationId = 12,
                    Remarks ="All mouse",
                    DateRecieve = DateTime.UtcNow.AddDays(-15),
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

            var assets = new Asset[]
              {
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "333-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "111-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    SerialNumber = "444-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "555-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },  new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "666-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "777-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "888-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "999-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                       new Asset {
                    ClientInformationId = 1,
                    ItemId = 2,
                    VendorId = 2,
                    SerialNumber = "1212-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "1111-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset {
                    ClientInformationId = 1,
                    ItemId = 2,
                    VendorId = 2,
                    SerialNumber = "1313-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 1,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "1414-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                     new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "1515-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "1616-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "1717-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "1818-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },  new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    SerialNumber = "1919-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "2020-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 2,
                    SerialNumber = "2121-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 2,
                    ItemId = 1,
                    VendorId = 1,
                    SerialNumber = "2222-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                       new Asset {
                    ClientInformationId = 2,
                    ItemId = 2,
                    VendorId = 2,
                    SerialNumber = "2323-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 2,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "2424-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
               new Asset {
                    ClientInformationId = 2,
                    ItemId = 2,
                    VendorId = 2,
                    SerialNumber = "2525-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new Asset {
                    ClientInformationId = 2,
                    ItemId = 2,
                    VendorId = 1,
                    SerialNumber = "2626-222-3333-xxx-11",
                    DateRecieve = DateTime.UtcNow.AddDays(-20),
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
                    ContactEmailAddress = "test@rrr.com",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation { 
                    CompanyName = "CurlyBytes",  
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ContactEmailAddress = "bbb@bb.com",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation {
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    ContactEmailAddress = "CC@cc.com",
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
                    HasCustomerAlreadyAgreed = true,
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
                    HasCustomerAlreadyAgreed = false,
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
                    HasCustomerAlreadyAgreed = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                }
            };

            var jobQuotationDetails = new JobQuotationDetails[] {
                 new JobQuotationDetails{ 
                    ItemId = 1,
                    Quantity = 2,
                    Price = 20,
                    Margin = 100,
                    Cost = 120,
                    ItemName = "Razer x123",
                    TotalCost = 240,
                    JobQuotationId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    ItemId = 2,
                    Quantity = 1,
                    Price = 200,
                    Margin = 30,
                    Cost = 230,
                    ItemName = "Jedel z31",
                    TotalCost = 230,
                    JobQuotationId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                  new JobQuotationDetails{
                    ItemId = 3,
                    Quantity = 3,
                    Price = 100,
                    Margin = 20,
                    Cost = 120,
                    ItemName = "Razer x33",
                    TotalCost = 360,
                    JobQuotationId = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    ItemId = 4,
                    Quantity = 3,
                    Price = 200,
                    Margin = 30,
                    Cost = 230,
                    ItemName = "Jedel z524",
                    TotalCost = 390,
                    JobQuotationId = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    ItemId = 5,
                    Quantity = 2,
                    Price = 200,
                    Margin = 30,
                    Cost = 230,
                    ItemName = "Razer x123",
                    TotalCost = 460,
                    JobQuotationId = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 },
                 new JobQuotationDetails{
                    ItemId = 6,
                    Quantity = 1,
                    Price = 100,
                    Margin = 20,
                    Cost = 120,
                    ItemName = "Razer x33",
                    TotalCost = 120,
                    JobQuotationId = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                 }
    
            };
            context.Warehouses.AddRange(warehouses);
            context.Vendors.AddRange(vendors);
            context.Items.AddRange(items);
            context.Assets.AddRange(assets);
            context.DeliveryReceipts.AddRange(deliveryReceipts);
            context.DeliveryReceiptDetailss.AddRange(deliveryReceiptDetails);
            context.ClientInformations.AddRange(clientInformations);
            context.JobOrders.AddRange(jobOrders);
            context.JobQuotations.AddRange(jobQuotation);
            context.JobQuotationDetailss.AddRange(jobQuotationDetails);
            context.SaveChanges();
        }
    }
}
