using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
  

    public class SqlServerJobOrderQuotationDetails : ISqlServerJobOrderQuotationDetails
    {
        private readonly AnthuriumContext _context;


        public SqlServerJobOrderQuotationDetails(AnthuriumContext context)
        {
            _context = context;

        }

        public IEnumerable<JobQuotationDetails> GetJobQuotationDetails()
        {
            return _context.JobQuotationDetailss;
        }

        public IEnumerable<JobQuotationDetails> GetJobQuotationDetailsByJobQuotation(int Id)
        {
            var test = _context.JobQuotationDetailss.Where(p => p.JobQuotationId == Id);
            return test;
        }

        public JobQuotationDetails GetJobQuotationDetailsById(int Id)
        {
            return _context.JobQuotationDetailss.FirstOrDefault(p => p.JobQuotationDetailsId == Id);
        }


        public void NewJobQuotationDetails(JobQuotationDetails JobQuotationDetails)
        {
            if (JobQuotationDetails == null)
            {
                throw new ArgumentNullException(nameof(JobQuotationDetails));
            }

            _context.JobQuotationDetailss.Add(JobQuotationDetails);
        }

        public void RemoveJobQuotationDetails(JobQuotationDetails JobQuotationDetails)
        {
            if (JobQuotationDetails == null)
            {
                throw new ArgumentNullException(nameof(JobQuotationDetails));
            }

            _context.JobQuotationDetailss.Remove(JobQuotationDetails);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateJobQuotationDetails(JobQuotationDetails JobQuotationDetails)
        {
            //nothing
        }

    }
}