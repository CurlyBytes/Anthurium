using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class JobOrderDescriptionOfWorkService : IJobOrderDescriptionOfWorkService
    {
        private IHttpService _httpService;

        public JobOrderDescriptionOfWorkService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<JobOrderDescriptionOfWorkApiResponse> GetJobOrderDescriptionOfWorksAsync(string orderBy, int skip, int top)
        {
            return await _httpService.Get<JobOrderDescriptionOfWorkApiResponse>($"api/joborderdescriptionofwork?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

        }

        public async Task<JobOrderDescriptionOfWorkReadDto> GetJobOrderDescriptionOfWorkByIdAsync(int id)
        {
            return await _httpService.Get<JobOrderDescriptionOfWorkReadDto>($"api/joborderdescriptionofwork/{id}");

        }

        public async Task DeleteJobOrderDescriptionOfWorkByIdAsync(int id)
        {
            //consider impact vs returning just status code
            await _httpService.Delete($"api/joborderdescriptionofwork/{id}");
        }

        public async Task<HttpResponseMessage> CreateJobOrderDescriptionOfWorkAsync(JobOrderDescriptionOfWorkCreateDto joborderdescriptionofwork)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/joborderdescriptionofwork", joborderdescriptionofwork);
        }

        public async Task EditJobOrderDescriptionOfWorkAsync(long id, JobOrderDescriptionOfWorkUpdateDto joborderdescriptionofwork)
        {

            await _httpService.Put($"api/joborderdescriptionofwork/{id}", joborderdescriptionofwork);
        }
    }
}
