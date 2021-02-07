using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anthurium.API.Migrations
{
    public partial class _100 : Migration
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInformations", x => x.ClientInformationId);
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

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderDescriptionOfWorks_JobOrderId",
                table: "JobOrderDescriptionOfWorks",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_ClientInformationId",
                table: "JobOrders",
                column: "ClientInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOrderDescriptionOfWorks");

            migrationBuilder.DropTable(
                name: "JobOrders");

            migrationBuilder.DropTable(
                name: "ClientInformations");
        }
    }
}
