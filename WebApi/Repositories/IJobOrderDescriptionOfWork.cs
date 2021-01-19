using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IJobOrderDescriptionOfWork
    {
        bool SaveChanges();

        IEnumerable<JobOrderDescriptionOfWork> GetJobOrderDescriptionOfWork();
        JobOrderDescriptionOfWork JobOrderDescriptionOfWorkById(int Id);

        void NewJobOrderDescriptionOfWork(JobOrderDescriptionOfWork JobOrderDescriptionOfWork);

        void UpdateJobOrderDescriptionOfWork(JobOrderDescriptionOfWork JobOrderDescriptionOfWork);

        void RemoveJobOrderDescriptionOfWork(JobOrderDescriptionOfWork JobOrderDescriptionOfWork);
    }
}
