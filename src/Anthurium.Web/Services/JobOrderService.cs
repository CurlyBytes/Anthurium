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
    public class JobOrderService
    {
        public HttpClient _httpClient;

        public JobOrderService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<JobOrderApiResponse> GetJobOrdersAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/joborder?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobOrderApiResponse>(responseContent);
            }

            return new JobOrderApiResponse();
        }

        public async Task<JobOrderApiResponse> GetJobOrdersByClientInfoAsync(string orderBy, int skip, int top, int clientInformationId)
        {
            var response = await _httpClient.GetAsync($"api/joborder?$count=true&$filter=ClientInformationId eq {clientInformationId}&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobOrderApiResponse>(responseContent);
            }

            return new JobOrderApiResponse();
        }

        public async Task<JobOrderReadDto> GetJobOrderByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/joborder/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<JobOrderReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteJobOrderByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/joborder/{id}");
        }

        public async Task<HttpResponseMessage> CreateJobOrderAsync(JobOrderCreateDto joborderdescriptionofwork)
        {
            string jsonJobOrder = JsonSerializer.Serialize(joborderdescriptionofwork);
            var stringContent = new StringContent(jsonJobOrder, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/joborder", stringContent);
        }

        public async Task<HttpResponseMessage> EditJobOrderAsync(long id, JobOrderUpdateDto joborderdescriptionofwork)
        {
            string jsonJobOrder = JsonSerializer.Serialize(joborderdescriptionofwork);
            var stringContent = new StringContent(jsonJobOrder, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/joborder/{id}", stringContent);
        }
    }

}
