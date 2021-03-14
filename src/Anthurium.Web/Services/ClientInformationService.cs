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

        public async Task<HttpResponseMessage> DeleteClientInformationByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpService.Delete<HttpResponseMessage>($"api/clientinformation/{id}");
        }

        public async Task<HttpResponseMessage> CreateClientInformationAsync(ClientInformationCreateDto clientinformation)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/clientinformation", clientinformation);
        }

        public async Task<HttpResponseMessage> EditClientInformationAsync(int id, ClientInformationUpdateDto clientinformation)
        {


            return await _httpService.Put<HttpResponseMessage>($"api/clientinformation/{id}", clientinformation);
        }
    }
}
