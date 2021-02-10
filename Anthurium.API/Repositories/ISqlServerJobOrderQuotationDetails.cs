using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories
{
    public interface ISqlServerJobOrderQuotationDetails
    {
        IEnumerable<JobQuotationDetails> GetJobQuotationDetails();
        IEnumerable<JobQuotationDetails> GetJobQuotationDetailsByJobQuotation(int Id);
        JobQuotationDetails GetJobQuotationDetailsById(int Id);
        void NewJobQuotationDetails(JobQuotationDetails JobQuotationDetails);
        void RemoveJobQuotationDetails(JobQuotationDetails JobQuotationDetails);
        bool SaveChanges();
        void UpdateJobQuotationDetails(JobQuotationDetails JobQuotationDetails);
    }
}
