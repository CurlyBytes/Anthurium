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
    public class JobQuotationDetailsDetails
    {
        public HttpClient _httpClient;

        public JobQuotationDetailsDetails(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<JobQuotationDetailsApiResponse> GetJobQuotationDetailssAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/jobquotationdetails?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobQuotationDetailsApiResponse>(responseContent);
            }

            return new JobQuotationDetailsApiResponse();
        }


        public async Task<JobQuotationDetailsApiResponse> JobQuotationDetailsByJobOrder(string orderBy, int skip, int top, int jobQuotationId)
        {
            var response = await _httpClient.GetAsync($"api/jobquotationdetails?$count=true&$filter=JobQuotationId eq {jobQuotationId}$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JobQuotationDetailsApiResponse>(responseContent);
            }

            return new JobQuotationDetailsApiResponse();
        }

        public async Task<JobQuotationDetailsReadDto> GetJobQuotationDetailsByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/jobquotationdetails/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<JobQuotationDetailsReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteJobQuotationDetailsByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/jobquotationdetails/{id}");
        }

        public async Task<HttpResponseMessage> CreateJobQuotationDetailsAsync(JobQuotationDetailsCreateDto clientinformation)
        {
            string jsonJobQuotationDetails = JsonSerializer.Serialize(clientinformation);
            var stringContent = new StringContent(jsonJobQuotationDetails, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/jobquotationdetails", stringContent);
        }

        public async Task<HttpResponseMessage> EditJobQuotationDetailsAsync(int id, JobQuotationDetailsUpdateDto clientinformation)
        {
            string jsonJobQuotationDetails = JsonSerializer.Serialize(clientinformation);
            var stringContent = new StringContent(jsonJobQuotationDetails, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/jobquotationdetails/{id}", stringContent);
        }
    }
}
