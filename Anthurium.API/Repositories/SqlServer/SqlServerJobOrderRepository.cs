using Anthurium.API.Data;
using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anthurium.Web.Repositories.SqlServer
{
    public class SqlServerJobOrderRepository : IJobOrderRepository
    {
        private readonly AnthuriumContext _context;

        public SqlServerJobOrderRepository(AnthuriumContext context)
        {
            _context = context;

        }
        public void CreateJobOrder(JobOrder JobOrder)
        {
            if (JobOrder == null)
            {
                throw new ArgumentNullException(nameof(JobOrder));
            }

            _context.JobOrders.Add(JobOrder);
        }

        public void DeleteJobOrder(JobOrder JobOrder)
        {
            if (JobOrder == null)
            {
                throw new ArgumentNullException(nameof(JobOrder));
            }

            _context.JobOrders.Remove(JobOrder);
        }

        public JobOrder GetJobOrderById(int Id)
        {
            return _context.JobOrders.FirstOrDefault(p => p.JobOrderId == Id);
        }

        public IEnumerable<JobOrder> GetJobOrders()
        {
            return _context.JobOrders.ToList();
        }

        public int NewClientByDateWithin30Days()
        {
            var valueDate = DateTime.UtcNow;
            return _context.JobOrders
                .Where(ci => ci.IsActive == true
                    && ci.DateCreated <= valueDate.AddDays(-30)
                    && ci.DateCreated >= valueDate)
                .Count();
        }


        public IQueryable<JobOrderPerClientReadDto> RunningTotalOfCompletedJobOrderPerClient()
        {

            var query = _context
        .JobOrders.GroupBy(x => x.CompanyName)
        .Select(x => new JobOrderPerClientReadDto { CompanyName = x.Key, NumberOfJobOrder = x.Count() });

     
            return query;

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateCJobOrder(JobOrder JobOrder)
        {
            //nothing
        }
    }
}
