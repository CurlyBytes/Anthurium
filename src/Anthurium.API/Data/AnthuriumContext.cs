﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anthurium.Shared.Models;


namespace Anthurium.API.Data
{
    public class AnthuriumContext : DbContext
    {
        public AnthuriumContext(DbContextOptions<AnthuriumContext> options) : base(options)
        {
        }
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Item> Items  { get; set; }
        public DbSet<JobQuotation> JobQuotations { get; set; }
        public DbSet<JobQuotationDetails> JobQuotationDetailss { get; set; }


        public DbSet<Asset> Assets { get; set; }
        public DbSet<DeliveryReceipt> DeliveryReceipts { get; set; }

        public DbSet<DeliveryReceiptDetails> DeliveryReceiptDetailss { get; set; }
        public DbSet<ClientInformation> ClientInformations { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<JobOrder> JobOrders { get; set; }
        public DbSet<JobOrderDescriptionOfWork> JobOrderDescriptionOfWorks { get; set; }
    }
}
