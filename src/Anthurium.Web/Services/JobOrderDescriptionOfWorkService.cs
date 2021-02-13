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
    public class JobOrderDescriptionOfWorkService
    {
        public HttpClient _httpClient;

        public JobOrderDescriptionOfWorkService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<JobOrderDescriptionOfWorkApiResponse> GetJobOrderDescriptionOfWorksAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/joborderdescriptionofwork?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobOrderDescriptionOfWorkApiResponse>(responseContent);
            }

            return new JobOrderDescriptionOfWorkApiResponse();
        }

        public async Task<JobOrderDescriptionOfWorkReadDto> GetJobOrderDescriptionOfWorkByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/joborderdescriptionofwork/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<JobOrderDescriptionOfWorkReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteJobOrderDescriptionOfWorkByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/joborderdescriptionofwork/{id}");
        }

        public async Task<HttpResponseMessage> CreateJobOrderDescriptionOfWorkAsync(JobOrderDescriptionOfWorkCreateDto joborderdescriptionofwork)
        {
            string jsonJobOrderDescriptionOfWork = JsonSerializer.Serialize(joborderdescriptionofwork);
            var stringContent = new StringContent(jsonJobOrderDescriptionOfWork, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/joborderdescriptionofwork", stringContent);
        }

        public async Task<HttpResponseMessage> EditJobOrderDescriptionOfWorkAsync(long id, JobOrderDescriptionOfWorkUpdateDto joborderdescriptionofwork)
        {
            string jsonJobOrderDescriptionOfWork = JsonSerializer.Serialize(joborderdescriptionofwork);
            var stringContent = new StringContent(jsonJobOrderDescriptionOfWork, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/joborderdescriptionofwork/{id}", stringContent);
        }
    }
}
