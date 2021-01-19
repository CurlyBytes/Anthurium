using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IJobOrderRepository
    {
        bool SaveChanges();

        IEnumerable<JobOrder> GetJobOrders();
        JobOrder GetJobOrderById(int Id);

        void CreateJobOrder(JobOrder JobOrder);

        void UpdateCJobOrder(JobOrder JobOrder);

        void DeleteJobOrder(JobOrder JobOrder);

        JobOrder RunningTotalOfCompletedJobOrder(int Id);
    }
}
