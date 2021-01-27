using Microsoft.EntityFrameworkCore;
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

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ClientInformation> ClientInformations { get; set; }
        public DbSet<JobOrder> JobOrders { get; set; }
        public DbSet<JobOrderDescriptionOfWork> JobOrderDescriptionOfWorks { get; set; }
    }
}
