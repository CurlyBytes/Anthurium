using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories.SqlServer
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
            return _context.JobOrders.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<JobOrder> GetJobOrders()
        {
            return _context.JobOrders.ToList();
        }

        public JobOrder RunningTotalOfCompletedJobOrder(int Id)
        {
            throw new NotImplementedException();
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
