using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
public interface IJobOrderService
{
    Task<HttpResponseMessage> CreateJobOrderAsync(JobOrderCreateDto joborderdescriptionofwork);
    Task DeleteJobOrderByIdAsync(int id);
    Task EditJobOrderAsync(long id, JobOrderUpdateDto joborderdescriptionofwork);
    Task<JobOrderReadDto> GetJobOrderByIdAsync(int id);
    Task<JobOrderApiResponse> GetJobOrdersAsync(string orderBy, int skip, int top);
    Task<JobOrderApiResponse> GetJobOrdersByClientInfoAsync(string orderBy, int skip, int top, int clientInformationId);
}
}