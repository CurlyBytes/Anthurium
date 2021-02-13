using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories
{
    public interface ISqlServerJobQuotationRepository
    {
        IEnumerable<JobQuotation> GetJobQuotations();
        IEnumerable<ClientInformation> JobQuotationByClient(int clientInformationId);
        IEnumerable<JobQuotation> JobOrderQuotationById(int jobQuotationId);
        void NewJobQuotation(JobQuotation jobQuotation);
        void RemoveJobQuotation(JobQuotation jobQuotation);
        bool SaveChanges();
        void UpdateJobQuotation(JobQuotation jobQuotation);
        JobQuotation JobOrderQuotationByIdOnly(int jobQuotationId);
        
    }

}
