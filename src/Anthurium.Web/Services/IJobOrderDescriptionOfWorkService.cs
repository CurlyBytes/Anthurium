using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
public interface IJobOrderDescriptionOfWorkService
{
    Task<HttpResponseMessage> CreateJobOrderDescriptionOfWorkAsync(JobOrderDescriptionOfWorkCreateDto joborderdescriptionofwork);
    Task DeleteJobOrderDescriptionOfWorkByIdAsync(int id);
    Task EditJobOrderDescriptionOfWorkAsync(long id, JobOrderDescriptionOfWorkUpdateDto joborderdescriptionofwork);
    Task<JobOrderDescriptionOfWorkReadDto> GetJobOrderDescriptionOfWorkByIdAsync(int id);
    Task<JobOrderDescriptionOfWorkApiResponse> GetJobOrderDescriptionOfWorksAsync(string orderBy, int skip, int top);
}
}