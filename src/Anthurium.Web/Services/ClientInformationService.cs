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
    public class ClientInformationService : IClientInformationService
    {
        public IHttpService _httpService;

        public ClientInformationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ClientInformationApiResponse> GetClientInformationsAsync(string orderBy, int skip, int top)
        {
            return await _httpService.Get<ClientInformationApiResponse>($"api/clientinformation?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");


        }

        public async Task<ClientInformationApiResponse> GetClientInformationsAsync(string orderBy, int skip)
        {
            return await _httpService.Get<ClientInformationApiResponse>($"api/clientinformation?$count=true&$orderby={orderBy}&$skip={skip}");

        }

        public async Task<ClientInformationReadDto> GetClientInformationByIdAsync(int id)
        {
            return await _httpService.Get<ClientInformationReadDto>($"api/clientinformation/{id}");


        }

        public async Task DeleteClientInformationByIdAsync(int id)
        {
            //consider impact vs returning just status code
           await _httpService.Delete($"api/clientinformation/{id}");
        }

        public async Task<HttpResponseMessage> CreateClientInformationAsync(ClientInformationCreateDto clientinformation)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/clientinformation", clientinformation);
        }

        public async Task EditClientInformationAsync(int id, ClientInformationUpdateDto clientinformation)
        {


            await _httpService.Put($"api/clientinformation/{id}", clientinformation);
        }
    }
}
