using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class AssetService
    {
        public HttpClient _httpClient;

        public AssetService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<AssetApiResponse> GetAssetsAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/asset?$count=true&$expand=Vendor,Item,ClientInformation&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<AssetApiResponse>(responseContent);
            }

            return new AssetApiResponse();
        }


        public async Task<AssetApiResponse> GetAssetsAsync(string orderBy, int skip)
        {
            var response = await _httpClient.GetAsync($"api/asset?$count=true&$expand=Vendor,Item,ClientInformation&$orderby={orderBy}&$skip={skip}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<AssetApiResponse>(responseContent);
            }

            return new AssetApiResponse();
        }


        public async Task<AssetReadDto> GetAssetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/asset/{id}?$expand=Vendor,Item,ClientInformation");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<AssetReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteAssetByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/asset/{id}");
        }

        public async Task<HttpResponseMessage> CreateAssetAsync(AssetCreateDto asset)
        {
            string jsonAsset = JsonSerializer.Serialize(asset);
            var stringContent = new StringContent(jsonAsset, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/asset", stringContent);
        }

        public async Task<HttpResponseMessage> EditAssetAsync(int id, AssetUpdateDto asset)
        {
            string jsonAsset = JsonSerializer.Serialize(asset);
            var stringContent = new StringContent(jsonAsset, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PutAsync($"api/asset/{id}", stringContent);
        }
    }
}
