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
    public class ClientInformationService
    {
        public HttpClient _httpClient;

        public ClientInformationService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<ClientInformationApiResponse> GetClientInformationsAsync(string orderBy, int skip, int top)
        {
            var response = await _httpClient.GetAsync($"api/clientinformation?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ClientInformationApiResponse>(responseContent);
            }

            return new ClientInformationApiResponse();
        }

        public async Task<ClientInformationReadDto> GetClientInformationByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/clientinformation/{id}");

            //Handle more gracefully
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ClientInformationReadDto>(responseContent);
        }

        public async Task<HttpResponseMessage> DeleteClientInformationByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpClient.DeleteAsync($"api/clientinformation/{id}");
        }

        public async Task<HttpResponseMessage> CreateClientInformationAsync(ClientInformationCreateDto clientinformation)
        {
            string jsonClientInformation = JsonSerializer.Serialize(clientinformation);
            var stringContent = new StringContent(jsonClientInformation, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync($"api/clientinformation", stringContent);
        }

        public async Task<HttpResponseMessage> EditClientInformationAsync(long id, ClientInformationReadDto clientinformation)
        {
            string jsonClientInformation = JsonSerializer.Serialize(clientinformation);
            var stringContent = new StringContent(jsonClientInformation, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PatchAsync($"api/clientinformation/{id}", stringContent);
        }
    }
}
