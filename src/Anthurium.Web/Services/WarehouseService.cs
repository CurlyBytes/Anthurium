﻿using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class WarehouseService : IWarehouseService
    {
        private IHttpService _httpService;

        public WarehouseService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<WarehouseApiResponse> GetWarehousesAsync(string orderBy, int skip, int top)
        {
            var test = await _httpService.Get<WarehouseApiResponse>($"api/warehouse?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");
            return test;
        }


        public async Task<WarehouseApiResponse> GetWarehousesAsync(string orderBy, int skip)
        {
            var test =  await _httpService.Get<WarehouseApiResponse>($"api/warehouse?$count=true&$orderby={orderBy}&$skip={skip}");
            return test;
        }


        public async Task<WarehouseReadDto> GetWarehouseByIdAsync(int id)
        {
            return await _httpService.Get<WarehouseReadDto>($"api/warehouse/{id}");

        }

        public async Task<HttpResponseMessage> DeleteWarehouseByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpService.Delete<HttpResponseMessage>($"api/warehouse/{id}");
        }

        public async Task<HttpResponseMessage> CreateWarehouseAsync(WarehouseCreateDto warehouse)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/warehouse", warehouse);
        }

        public async Task<HttpResponseMessage> EditWarehouseAsync(int id, WarehouseUpdateDto warehouse)
        {

            return await _httpService.Put<HttpResponseMessage>($"api/warehouse/{id}", warehouse);
        }
    }
}
