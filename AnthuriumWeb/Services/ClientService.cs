using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;

namespace AnthuriumWeb.Services
{
    public class ClientService
    {
        public HttpClient _httpClient;

        public ClientService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<ClientInformationReadDto>> GetContactsAsync()
        {
            
            var response = await _httpClient.GetAsync("api/client");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ClientInformationReadDto>>(responseContent);
        }

    
    }
}
