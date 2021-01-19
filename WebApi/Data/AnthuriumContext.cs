using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class AnthuriumContext : DbContext
    {
        public AnthuriumContext(DbContextOptions<AnthuriumContext> opt) : base(opt)
        {

        }

        public DbSet<ClientInformation> ClientInformations { get; set; }
        public DbSet<JobOrder> JobOrders { get; set; }
        public DbSet<JobOrderDescriptionOfWork> JobOrderDescriptionOfWorks { get; set; }
    }
}
