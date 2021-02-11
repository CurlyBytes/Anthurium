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
    public class JobQuotationService
    {
        public HttpClient _httpClient;

        public JobQuotationService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<JobQuotationApiResponse> GetJobQuotationsAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/jobquotation?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobQuotationApiResponse>(responseContent);
            }

            return new JobQuotationApiResponse();
        }

        public async Task<JobQuotationApiResponse> JobOrderQuotationByClient(string orderBy, int skip, int top, int clientinformationId)
        {
            var response = await _httpClient.GetAsync($"api/jobquotation/ClientInformation(ClientInformationId={clientinformationId})?$expand=JobQuotation($count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobQuotationApiResponse>(responseContent);
            }

            return new JobQuotationApiResponse();
        }

     
        public async Task<JobQuotationReadDto> GetJobQuotationByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/jobquotation/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<JobQuotationReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteJobQuotationByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/jobquotation/{id}");
        }

        public async Task<HttpResponseMessage> CreateJobQuotationAsync(JobQuotationCreateDto clientinformation)
        {
            string jsonJobQuotation = JsonSerializer.Serialize(clientinformation);
            var stringContent = new StringContent(jsonJobQuotation, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/jobquotation", stringContent);
        }

        public async Task<HttpResponseMessage> EditJobQuotationAsync(int id, JobQuotationUpdateDto clientinformation)
        {
            string jsonJobQuotation = JsonSerializer.Serialize(clientinformation);
            var stringContent = new StringContent(jsonJobQuotation, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/jobquotation/{id}", stringContent);
        }
    }
}
