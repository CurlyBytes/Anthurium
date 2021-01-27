using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.Web.Repositories.SqlServer
{
    public class SqlServerJobOrderDescriptionOfWorkRepository : IJobOrderDescriptionOfWork
    {
        private readonly AnthuriumContext _context;


        public SqlServerJobOrderDescriptionOfWorkRepository(AnthuriumContext context)
        {
            _context = context;

        }
        public IEnumerable<JobOrderDescriptionOfWork> GetJobOrderDescriptionOfWork()
        {
            return _context.JobOrderDescriptionOfWorks.ToList();
        }

        public JobOrderDescriptionOfWork JobOrderDescriptionOfWorkById(int Id)
        {
            return _context.JobOrderDescriptionOfWorks.FirstOrDefault(p => p.Id == Id);
        }

        public void NewJobOrderDescriptionOfWork(JobOrderDescriptionOfWork JobOrderDescriptionOfWork)
        {
            if (JobOrderDescriptionOfWork == null)
            {
                throw new ArgumentNullException(nameof(JobOrderDescriptionOfWork));
            }

            _context.JobOrderDescriptionOfWorks.Add(JobOrderDescriptionOfWork);
        }

        public void RemoveJobOrderDescriptionOfWork(JobOrderDescriptionOfWork JobOrderDescriptionOfWork)
        {
            if (JobOrderDescriptionOfWork == null)
            {
                throw new ArgumentNullException(nameof(JobOrderDescriptionOfWork));
            }

            _context.JobOrderDescriptionOfWorks.Remove(JobOrderDescriptionOfWork);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateJobOrderDescriptionOfWork(JobOrderDescriptionOfWork JobOrderDescriptionOfWork)
        {
            //nothing
        }
    }
}
