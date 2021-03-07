using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class VendorService
    {
        public HttpClient _httpClient;

        public VendorService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<VendorApiResponse> GetVendorsAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/vendor?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<VendorApiResponse>(responseContent);
            }

            return new VendorApiResponse();
        }


        public async Task<VendorApiResponse> GetVendorsAsync(string orderBy, int skip)
        {
            var response = await _httpClient.GetAsync($"api/vendor?$count=true&$orderby={orderBy}&$skip={skip}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<VendorApiResponse>(responseContent);
            }

            return new VendorApiResponse();
        }

        public async Task<VendorReadDto> GetVendorByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/vendor/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<VendorReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteVendorByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/vendor/{id}");
        }

        public async Task<HttpResponseMessage> CreateVendorAsync(VendorCreateDto vendor)
        {
            string jsonVendor = JsonSerializer.Serialize(vendor);
            var stringContent = new StringContent(jsonVendor, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/vendor", stringContent);
        }

        public async Task<HttpResponseMessage> EditVendorAsync(int id, VendorUpdateDto vendor)
        {
            string jsonVendor = JsonSerializer.Serialize(vendor);
            var stringContent = new StringContent(jsonVendor, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/vendor/{id}", stringContent);
        }
    }
}
