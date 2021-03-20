using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anthurium.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientInformations",
                columns: table => new
                {
                    ClientInformationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    CompanyAddress = table.Column<string>(maxLength: 450, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 300, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ContactEmailAddress = table.Column<string>(maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInformations", x => x.ClientInformationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(maxLength: 100, nullable: false),
                    VendorCode = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WarehouseName = table.Column<string>(maxLength: 100, nullable: false),
                    WarehouseCode = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "JobOrders",
                columns: table => new
                {
                    JobOrderId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    CompanyAddress = table.Column<string>(maxLength: 450, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 300, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 20, nullable: false),
                    TimeStarted = table.Column<DateTime>(nullable: false),
                    TimeEnded = table.Column<DateTime>(nullable: false),
                    TotalHours = table.Column<int>(nullable: false),
                    DateSchedule = table.Column<DateTime>(nullable: false),
                    JoboRderDescription = table.Column<string>(maxLength: 500, nullable: false),
                    RemainingHours = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ClientInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOrders", x => x.JobOrderId);
                    table.ForeignKey(
                        name: "FK_JobOrders_ClientInformations_ClientInformationId",
                        column: x => x.ClientInformationId,
                        principalTable: "ClientInformations",
                        principalColumn: "ClientInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobQuotations",
                columns: table => new
                {
                    JobQuotationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    CompanyAddress = table.Column<string>(maxLength: 450, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 300, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ContactEmailAddress = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: false),
                    OverallCost = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    HasCustomerAlreadyAgreed = table.Column<bool>(nullable: false),
                    ClientInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobQuotations", x => x.JobQuotationId);
                    table.ForeignKey(
                        name: "FK_JobQuotations_ClientInformations_ClientInformationId",
                        column: x => x.ClientInformationId,
                        principalTable: "ClientInformations",
                        principalColumn: "ClientInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemType = table.Column<string>(maxLength: 50, nullable: false),
                    ItemGroup = table.Column<string>(maxLength: 50, nullable: false),
                    ItemCode = table.Column<string>(maxLength: 50, nullable: false),
                    ItemName = table.Column<string>(maxLength: 150, nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOrderDescriptionOfWorks",
                columns: table => new
                {
                    JobOrderDescriptionOfWorkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobOrderTypeOfWOrk = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    JobOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOrderDescriptionOfWorks", x => x.JobOrderDescriptionOfWorkId);
                    table.ForeignKey(
                        name: "FK_JobOrderDescriptionOfWorks_JobOrders_JobOrderId",
                        column: x => x.JobOrderId,
                        principalTable: "JobOrders",
                        principalColumn: "JobOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryReceipts",
                columns: table => new
                {
                    DeliveryReceiptId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientInformationId = table.Column<int>(nullable: false),
                    JobQuotationId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 250, nullable: false),
                    DateRecieve = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryReceipts", x => x.DeliveryReceiptId);
                    table.ForeignKey(
                        name: "FK_DeliveryReceipts_ClientInformations_ClientInformationId",
                        column: x => x.ClientInformationId,
                        principalTable: "ClientInformations",
                        principalColumn: "ClientInformationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryReceipts_JobQuotations_JobQuotationId",
                        column: x => x.JobQuotationId,
                        principalTable: "JobQuotations",
                        principalColumn: "JobQuotationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientInformationId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 200, nullable: false),
                    WarrantyDate = table.Column<DateTime>(nullable: false),
                    DateRecieve = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_ClientInformations_ClientInformationId",
                        column: x => x.ClientInformationId,
                        principalTable: "ClientInformations",
                        principalColumn: "ClientInformationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobQuotationDetailss",
                columns: table => new
                {
                    JobQuotationDetailsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobQuotationId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(maxLength: 150, nullable: false),
                    MarginPrice = table.Column<double>(nullable: false),
                    OriginalPrice = table.Column<double>(nullable: false),
                    SellingPrice = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    IsAlreadyPurchaseOrder = table.Column<bool>(nullable: false),
                    PurchaseOrderCode = table.Column<string>(maxLength: 75, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobQuotationDetailss", x => x.JobQuotationDetailsId);
                    table.ForeignKey(
                        name: "FK_JobQuotationDetailss_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobQuotationDetailss_JobQuotations_JobQuotationId",
                        column: x => x.JobQuotationId,
                        principalTable: "JobQuotations",
                        principalColumn: "JobQuotationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryReceiptDetailss",
                columns: table => new
                {
                    DeliveryReceiptDetailsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeliveryReceiptId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryReceiptDetailss", x => x.DeliveryReceiptDetailsId);
                    table.ForeignKey(
                        name: "FK_DeliveryReceiptDetailss_DeliveryReceipts_DeliveryReceiptId",
                        column: x => x.DeliveryReceiptId,
                        principalTable: "DeliveryReceipts",
                        principalColumn: "DeliveryReceiptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryReceiptDetailss_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientInformations",
                columns: new[] { "ClientInformationId", "CompanyAddress", "CompanyName", "ContactEmailAddress", "ContactNumber", "ContactPerson", "DateCreated", "DateUpdated", "IsActive" },
                values: new object[,]
                {
                    { 1, "eduardo aboitiz street", "AMA", "test@rrr.com", "1134455", "Tao yang", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(2216), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(2615), true },
                    { 2, "107 v. raman st. calamba cc", "CurlyBytes", "bbb@bb.com", "09866191", "bob uy", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(3092), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(3103), true },
                    { 3, "United States America", "Microsoft", "CC@cc.com", "1134455", "sicnarf noyag", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(3110), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(3111), true }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorId", "DateCreated", "DateUpdated", "IsActive", "VendorCode", "VendorName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(9217), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(9617), true, "MS", "Microsoft" },
                    { 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(50), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(62), true, "DL1", "Dell" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "DateCreated", "DateUpdated", "IsActive", "WarehouseCode", "WarehouseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 19, 15, 42, 49, 963, DateTimeKind.Utc).AddTicks(7925), new DateTime(2021, 3, 19, 15, 42, 49, 963, DateTimeKind.Utc).AddTicks(8393), true, "t-w-1", "The warehouse 1" },
                    { 2, new DateTime(2021, 3, 19, 15, 42, 49, 963, DateTimeKind.Utc).AddTicks(8867), new DateTime(2021, 3, 19, 15, 42, 49, 963, DateTimeKind.Utc).AddTicks(8880), true, "t-w-2", "The warehouse 2" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryReceipts",
                columns: new[] { "DeliveryReceiptId", "ClientInformationId", "DateCreated", "DateRecieve", "DateUpdated", "IsActive", "JobQuotationId", "Remarks" },
                values: new object[] { 3, 2, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(7110), new DateTime(2021, 3, 4, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(7109), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(7111), true, 12, "All mouse" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "DateCreated", "DateUpdated", "IsActive", "ItemCode", "ItemGroup", "ItemName", "ItemType", "WarehouseId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9064), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9065), true, "m-cs-1", "Computer Set", "Jedel z524", "Mouse", 2 },
                    { 6, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9061), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9061), true, "m-cs-1", "Computer Set", "Jedel z31", "Mouse", 2 },
                    { 5, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9059), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9060), true, "m-cs-1", "Computer Set", "Razer x123", "Mouse", 2 },
                    { 4, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9057), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9058), true, "m-cs-1", "Computer Set", "Jedel z524", "Mouse", 1 },
                    { 3, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9054), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9055), false, "m-cs-1", "Computer Set", "Razer x33", "Mouse", 1 },
                    { 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(8976), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(8987), true, "m-cs-1", "Computer Set", "Jedel z31", "Mouse", 1 },
                    { 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(8131), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(8530), true, "m-cs-1", "Computer Set", "Razer x123", "Mouse", 1 },
                    { 7, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9063), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(9063), true, "m-cs-1", "Computer Set", "Razer x33", "Mouse", 2 }
                });

            migrationBuilder.InsertData(
                table: "JobOrders",
                columns: new[] { "JobOrderId", "ClientInformationId", "CompanyAddress", "CompanyName", "ContactNumber", "ContactPerson", "DateCreated", "DateSchedule", "DateUpdated", "IsActive", "JoboRderDescription", "RemainingHours", "TimeEnded", "TimeStarted", "TotalHours" },
                values: new object[,]
                {
                    { 1, 1, "eduardo aboitiz street", "AMA", "+0639207082", "amaers", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(8664), new DateTime(2021, 3, 21, 22, 42, 49, 967, DateTimeKind.Utc).AddTicks(6113), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9043), true, "another work heree", 2, new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(7601), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(7219), 2 },
                    { 5, 2, "107 v. raman st. calamba cc", "CurlyBytes", "4177214", "Cacay", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9551), new DateTime(2021, 3, 28, 2, 42, 49, 967, DateTimeKind.Utc).AddTicks(9548), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9552), true, "job order", 4, new DateTime(2021, 3, 21, 9, 42, 49, 967, DateTimeKind.Utc).AddTicks(9550), new DateTime(2021, 3, 20, 2, 42, 49, 967, DateTimeKind.Utc).AddTicks(9549), 3 },
                    { 4, 2, "107 v. raman st. calamba cc", "CurlyBytes", "4177214", "Cocoy", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9547), new DateTime(2021, 4, 19, 13, 42, 49, 967, DateTimeKind.Utc).AddTicks(9544), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9547), true, "lazy work", 1, new DateTime(2021, 3, 19, 17, 42, 49, 967, DateTimeKind.Utc).AddTicks(9546), new DateTime(2021, 3, 19, 16, 42, 49, 967, DateTimeKind.Utc).AddTicks(9545), 1 },
                    { 3, 1, "eduardo aboitiz street", "AMA", "+0639207082", "amaers", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9542), new DateTime(2021, 3, 22, 5, 42, 49, 967, DateTimeKind.Utc).AddTicks(9539), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9543), true, "this a manual work here", 4, new DateTime(2021, 3, 19, 17, 42, 49, 967, DateTimeKind.Utc).AddTicks(9541), new DateTime(2021, 3, 19, 16, 42, 49, 967, DateTimeKind.Utc).AddTicks(9540), 1 },
                    { 2, 1, "eduardo aboitiz street", "AMA", "+0639207082", "amaers", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9523), new DateTime(2021, 3, 21, 19, 42, 49, 967, DateTimeKind.Utc).AddTicks(9472), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9530), true, "this a manual work here", 4, new DateTime(2021, 3, 21, 2, 42, 49, 967, DateTimeKind.Utc).AddTicks(9505), new DateTime(2021, 3, 20, 3, 42, 49, 967, DateTimeKind.Utc).AddTicks(9498), 31 },
                    { 6, 3, "United States America", "Microsoft", "21141", "Trump", new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9556), new DateTime(2021, 4, 2, 11, 42, 49, 967, DateTimeKind.Utc).AddTicks(9553), new DateTime(2021, 3, 19, 15, 42, 49, 967, DateTimeKind.Utc).AddTicks(9556), true, "test work", 4, new DateTime(2021, 3, 20, 3, 42, 49, 967, DateTimeKind.Utc).AddTicks(9555), new DateTime(2021, 3, 19, 16, 42, 49, 967, DateTimeKind.Utc).AddTicks(9554), 8 }
                });

            migrationBuilder.InsertData(
                table: "JobQuotations",
                columns: new[] { "JobQuotationId", "ClientInformationId", "CompanyAddress", "CompanyName", "ContactEmailAddress", "ContactNumber", "ContactPerson", "DateCreated", "DateUpdated", "Description", "HasCustomerAlreadyAgreed", "IsActive", "OverallCost" },
                values: new object[,]
                {
                    { 2, 1, "eduardo aboitiz street", "AMA", "aaa@tset.com", "+0639207082", "amaers", new DateTime(2021, 3, 19, 15, 42, 49, 968, DateTimeKind.Utc).AddTicks(5277), new DateTime(2021, 3, 19, 15, 42, 49, 968, DateTimeKind.Utc).AddTicks(5287), "Sample Job Quotation From AMA", false, true, 200.0 },
                    { 1, 1, "eduardo aboitiz street", "AMA", "tset@tset.com", "+0639207082", "amaers", new DateTime(2021, 3, 19, 15, 42, 49, 968, DateTimeKind.Utc).AddTicks(4321), new DateTime(2021, 3, 19, 15, 42, 49, 968, DateTimeKind.Utc).AddTicks(4721), "Sample Job Quotation From AMA", true, true, 100.0 },
                    { 3, 2, "107 v. raman st. calamba cc", "CurlyBytes", "fff@tset.com", "4177214", "Cocoy", new DateTime(2021, 3, 19, 15, 42, 49, 968, DateTimeKind.Utc).AddTicks(5296), new DateTime(2021, 3, 19, 15, 42, 49, 968, DateTimeKind.Utc).AddTicks(5296), "CurlyBytes JobQuote", true, true, 300.0 }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "ClientInformationId", "DateCreated", "DateRecieve", "DateUpdated", "IsActive", "ItemId", "SerialNumber", "VendorId", "WarrantyDate" },
                values: new object[,]
                {
                    { 18, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4853), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4852), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4854), true, 1, "2020-222-3333-xxx-11", 2, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4850) },
                    { 11, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4793), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4792), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4794), true, 2, "1313-222-3333-xxx-11", 2, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4791) },
                    { 10, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4789), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4789), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4790), true, 2, "1111-222-3333-xxx-11", 1, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4787) },
                    { 9, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4786), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4785), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4786), true, 2, "1212-222-3333-xxx-11", 2, new DateTime(2022, 6, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4784) },
                    { 22, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4873), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4872), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4874), true, 2, "2424-222-3333-xxx-11", 1, new DateTime(2022, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4871) },
                    { 20, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4863), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4862), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4864), true, 1, "2222-222-3333-xxx-11", 1, new DateTime(2023, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4860) },
                    { 19, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4858), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4857), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4859), true, 1, "2121-222-3333-xxx-11", 2, new DateTime(2022, 5, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4856) },
                    { 23, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4879), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4877), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4879), true, 2, "2525-222-3333-xxx-11", 2, new DateTime(2022, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4876) },
                    { 17, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4847), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4817), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4848), true, 1, "1919-222-3333-xxx-11", 0, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4816) },
                    { 16, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4814), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4813), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4814), true, 1, "1818-222-3333-xxx-11", 1, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4812) },
                    { 15, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4810), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4809), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4811), true, 1, "1717-222-3333-xxx-11", 2, new DateTime(2024, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4807) },
                    { 14, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4805), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4804), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4806), true, 1, "1616-222-3333-xxx-11", 1, new DateTime(2023, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4803) },
                    { 13, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4801), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4800), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4802), true, 1, "1515-222-3333-xxx-11", 2, new DateTime(2023, 2, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4798) },
                    { 8, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4782), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4781), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4783), true, 1, "999-222-3333-xxx-11", 1, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4780) },
                    { 7, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4778), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4777), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4779), true, 1, "888-222-3333-xxx-11", 2, new DateTime(2022, 5, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4776) },
                    { 6, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4774), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4773), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4775), true, 1, "777-222-3333-xxx-11", 1, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4772) },
                    { 5, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4770), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4769), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4771), true, 1, "666-222-3333-xxx-11", 2, new DateTime(2023, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4768) },
                    { 4, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4766), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4765), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4766), true, 1, "555-222-3333-xxx-11", 1, new DateTime(2022, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4763) },
                    { 3, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4761), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4760), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4762), true, 1, "444-222-3333-xxx-11", 0, new DateTime(2023, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4759) },
                    { 2, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4742), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4728), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4752), true, 1, "111-222-3333-xxx-11", 2, new DateTime(2023, 9, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4708) },
                    { 1, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(3861), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(3038), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4257), true, 1, "333-222-3333-xxx-11", 1, new DateTime(2022, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(2568) },
                    { 24, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4884), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4882), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4884), true, 2, "2626-222-3333-xxx-11", 1, new DateTime(2022, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4881) },
                    { 12, 1, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4797), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4796), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4797), true, 2, "1414-222-3333-xxx-11", 1, new DateTime(2023, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4795) },
                    { 21, 2, new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4868), new DateTime(2021, 2, 27, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4867), new DateTime(2021, 3, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4869), true, 2, "2323-222-3333-xxx-11", 2, new DateTime(2022, 11, 19, 15, 42, 49, 966, DateTimeKind.Utc).AddTicks(4865) }
                });

            migrationBuilder.InsertData(
                table: "DeliveryReceipts",
                columns: new[] { "DeliveryReceiptId", "ClientInformationId", "DateCreated", "DateRecieve", "DateUpdated", "IsActive", "JobQuotationId", "Remarks" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(6226), new DateTime(2021, 2, 22, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(5377), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(6625), true, 1, "All mouse" },
                    { 2, 1, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(7094), new DateTime(2021, 3, 4, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(7059), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(7100), true, 1, "All keyboard" }
                });

            migrationBuilder.InsertData(
                table: "JobQuotationDetailss",
                columns: new[] { "JobQuotationDetailsId", "DateCreated", "DateUpdated", "IsActive", "IsAlreadyPurchaseOrder", "ItemId", "ItemName", "JobQuotationId", "MarginPrice", "OriginalPrice", "PurchaseOrderCode", "Quantity", "SellingPrice", "TotalCost" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1170), new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1171), true, false, 5, "Razer x123", 2, 30.0, 200.0, "", 2, 230.0, 460.0 },
                    { 2, new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1146), new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1156), true, true, 2, "Jedel z31", 1, 30.0, 200.0, "ffff-111", 1, 230.0, 230.0 },
                    { 3, new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1165), new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1166), true, false, 3, "Razer x33", 1, 20.0, 100.0, "", 3, 120.0, 360.0 },
                    { 4, new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1168), new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1169), true, true, 4, "Jedel z524", 2, 30.0, 200.0, "ffff-111", 3, 230.0, 390.0 },
                    { 1, new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(214), new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(613), true, true, 1, "Razer x123", 1, 100.0, 20.0, "ffff-111", 2, 120.0, 240.0 },
                    { 6, new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1172), new DateTime(2021, 3, 19, 15, 42, 49, 969, DateTimeKind.Utc).AddTicks(1173), true, false, 6, "Razer x33", 3, 20.0, 100.0, "", 1, 120.0, 120.0 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryReceiptDetailss",
                columns: new[] { "DeliveryReceiptDetailsId", "DateCreated", "DateUpdated", "DeliveryReceiptId", "IsActive", "ItemId", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(2262), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(2695), 1, true, 1, 2 },
                    { 2, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(3157), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(3170), 1, true, 2, 2 },
                    { 3, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(3178), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(3179), 2, true, 1, 1 },
                    { 4, new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(3180), new DateTime(2021, 3, 19, 15, 42, 49, 965, DateTimeKind.Utc).AddTicks(3181), 2, true, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ClientInformationId",
                table: "Assets",
                column: "ClientInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ItemId",
                table: "Assets",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_VendorId",
                table: "Assets",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryReceiptDetailss_DeliveryReceiptId",
                table: "DeliveryReceiptDetailss",
                column: "DeliveryReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryReceiptDetailss_ItemId",
                table: "DeliveryReceiptDetailss",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryReceipts_ClientInformationId",
                table: "DeliveryReceipts",
                column: "ClientInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryReceipts_JobQuotationId",
                table: "DeliveryReceipts",
                column: "JobQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarehouseId",
                table: "Items",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderDescriptionOfWorks_JobOrderId",
                table: "JobOrderDescriptionOfWorks",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_ClientInformationId",
                table: "JobOrders",
                column: "ClientInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobQuotationDetailss_ItemId",
                table: "JobQuotationDetailss",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_JobQuotationDetailss_JobQuotationId",
                table: "JobQuotationDetailss",
                column: "JobQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobQuotations_ClientInformationId",
                table: "JobQuotations",
                column: "ClientInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "DeliveryReceiptDetailss");

            migrationBuilder.DropTable(
                name: "JobOrderDescriptionOfWorks");

            migrationBuilder.DropTable(
                name: "JobQuotationDetailss");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "DeliveryReceipts");

            migrationBuilder.DropTable(
                name: "JobOrders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "JobQuotations");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "ClientInformations");
        }
    }
}
