using Anthurium.API.Dtos;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anthurium.Web.Repositories
{
    public interface IJobOrderRepository
    {
        bool SaveChanges();

        IEnumerable<JobOrder> GetJobOrders();
        JobOrder GetJobOrderById(int Id);

        void CreateJobOrder(JobOrder JobOrder);

        void UpdateCJobOrder(JobOrder JobOrder);

        void DeleteJobOrder(JobOrder JobOrder);

        int NewClientByDateWithin30Days();

        IQueryable<JobOrderPerClientReadDto> RunningTotalOfCompletedJobOrderPerClient();
    }
}
