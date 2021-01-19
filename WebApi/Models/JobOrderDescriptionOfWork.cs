using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class JobOrderDescriptionOfWork
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string JobOrderTypeOfWOrk { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool IsActive { get; set; }

        public ICollection<JobOrder> JobOrders { get; set; }
    }
}
