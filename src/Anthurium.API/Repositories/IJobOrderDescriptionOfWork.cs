using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anthurium.Web.Repositories
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
