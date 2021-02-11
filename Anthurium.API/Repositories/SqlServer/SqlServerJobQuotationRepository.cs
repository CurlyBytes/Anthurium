using Anthurium.API.Data;
using Anthurium.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{

    public class SqlServerJobQuotationRepository : ISqlServerJobQuotationRepository
    {
        private readonly AnthuriumContext _context;


        public SqlServerJobQuotationRepository(AnthuriumContext context)
        {
            _context = context;
        }

        public IEnumerable<JobQuotation> GetJobQuotations()
        {
            return _context.JobQuotations.ToList();
        }

        public IEnumerable<JobQuotation> JobOrderQuotationById(int jobQuotationId)
        {
            var result = _context.JobQuotations
                .Where(j => j.JobQuotationId == jobQuotationId)
                .Include(jq => jq.JobQuotationDetails.Where(jqd => jqd.JobQuotationId == jobQuotationId));
            return result;
        }

        public JobQuotation JobOrderQuotationByIdOnly(int jobQuotationId)
        {
            var result = _context.JobQuotations.FirstOrDefault(p => p.JobQuotationId == jobQuotationId);
            return result;
        }


        public IEnumerable<ClientInformation> JobQuotationByClient(int clientInformationId)
        {
            var result = _context.ClientInformations
                .Where(j => j.ClientInformationId == clientInformationId)
                .Include(jq => jq.JobQuotation);
            return result;
        }

        public void NewJobQuotation(JobQuotation jobQuotation)
        {
            if (jobQuotation == null)
            {
                throw new ArgumentNullException(nameof(jobQuotation));
            }

            _context.JobQuotations.Add(jobQuotation);
        }

        public void RemoveJobQuotation(JobQuotation jobQuotation)
        {
            if (jobQuotation == null)
            {
                throw new ArgumentNullException(nameof(jobQuotation));
            }

            _context.JobQuotations.Remove(jobQuotation);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateJobQuotation(JobQuotation jobQuotation)
        {
            //nothing
        }

    }
}
