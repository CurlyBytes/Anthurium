using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class WarehouseService
    {
        public HttpClient _httpClient;

        public WarehouseService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<WarehouseApiResponse> GetWarehousesAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/warehouse?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WarehouseApiResponse>(responseContent);
            }

            return new WarehouseApiResponse();
        }


        public async Task<WarehouseApiResponse> GetWarehousesAsync(string orderBy, int skip)
        {
            var response = await _httpClient.GetAsync($"api/warehouse?$count=true&$orderby={orderBy}&$skip={skip}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<WarehouseApiResponse>(responseContent);
            }

            return new WarehouseApiResponse();
        }


        public async Task<WarehouseReadDto> GetWarehouseByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/warehouse/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<WarehouseReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteWarehouseByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/warehouse/{id}");
        }

        public async Task<HttpResponseMessage> CreateWarehouseAsync(WarehouseCreateDto warehouse)
        {
            string jsonWarehouse = JsonSerializer.Serialize(warehouse);
            var stringContent = new StringContent(jsonWarehouse, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/warehouse", stringContent);
        }

        public async Task<HttpResponseMessage> EditWarehouseAsync(int id, WarehouseUpdateDto warehouse)
        {
            string jsonWarehouse = JsonSerializer.Serialize(warehouse);
            var stringContent = new StringContent(jsonWarehouse, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/warehouse/{id}", stringContent);
        }
    }
}
