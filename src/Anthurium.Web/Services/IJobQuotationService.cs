using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IJobQuotationService
    {
        Task<HttpResponseMessage> CreateJobQuotationAsync(JobQuotationCreateDto clientinformation);
        Task<HttpResponseMessage> DeleteJobQuotationByIdAsync(int id);
        Task<HttpResponseMessage> EditJobQuotationAsync(int id, JobQuotationUpdateDto clientinformation);
        Task<JobQuotationReadDto> GetJobQuotationByIdAsync(int id);
        Task<JobQuotationApiResponse> GetJobQuotationsAsync(string orderBy, int skip, int top);
        Task<JobQuotationApiResponse> JobOrderQuotationByClient(string orderBy, int skip, int top, int clientInformationId);
    }
}