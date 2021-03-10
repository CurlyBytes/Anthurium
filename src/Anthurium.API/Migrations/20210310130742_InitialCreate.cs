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
