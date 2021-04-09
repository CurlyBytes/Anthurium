using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services {
  public interface IJobQuotationDetailsDetails {
    Task<HttpResponseMessage> CreateJobQuotationDetailsAsync(
        JobQuotationDetailsCreateDto clientinformation);
    Task DeleteJobQuotationDetailsByIdAsync(int id);
    Task EditJobQuotationDetailsAsync(
        int id, JobQuotationDetailsUpdateDto clientinformation);
    Task<JobQuotationDetailsReadDto> GetJobQuotationDetailsByIdAsync(int id);
    Task<JobQuotationDetailsApiResponse> GetJobQuotationDetailssAsync(
        string orderBy, int skip, int top);
    Task<JobQuotationDetailsApiResponse> JobQuotationDetailsByJobOrder(
        string orderBy, int jobQuotationId);
    Task<JobQuotationDetailsApiResponse> JobQuotationDetailsByJobOrder(
        string orderBy, int skip, int top, int jobQuotationId);
  }
}
