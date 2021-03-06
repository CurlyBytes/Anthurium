using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class ItemService
    {
        public HttpClient _httpClient;

        public ItemService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<ItemApiResponse> GetItemsAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/item?$count=true&$expand=Warehouse&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ItemApiResponse>(responseContent);
            }

            return new ItemApiResponse();
        }



        public async Task<ItemReadDto> GetItemByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/item/{id}?$expand=Warehouse");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ItemReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteItemByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/item/{id}");
        }

        public async Task<HttpResponseMessage> CreateItemAsync(ItemCreateDto item)
        {
            string jsonItem = JsonSerializer.Serialize(item);
            var stringContent = new StringContent(jsonItem, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/item", stringContent);
        }

        public async Task<HttpResponseMessage> EditItemAsync(int id, ItemUpdateDto item)
        {
            string jsonItem = JsonSerializer.Serialize(item);
            var stringContent = new StringContent(jsonItem, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/item/{id}", stringContent);
        }
    }
}
