using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories
{
    public interface ISqlServerJobQuotationRepository
    {
        IEnumerable<JobQuotation> GetClientInformation();
        IEnumerable<ClientInformation> JobOrderQuotationByClient(int clientInformationId);
        IEnumerable<JobQuotation> JobOrderQuotationById(int jobQuotationId);
        void NewJobQuotation(JobQuotation jobQuotation);
        void RemoveClientInformation(JobQuotation jobQuotation);
        bool SaveChanges();
        void UpdateClientInformation(JobQuotation clientInformation);
    }

}
