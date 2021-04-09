using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class ItemService : IItemService
    {
        private IHttpService _httpService;

        public ItemService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ItemApiResponse> GetItemsAsync(string orderBy, int skip, int top)
        {
            return await _httpService.Get<ItemApiResponse>($"api/item?$count=true&$expand=Warehouse&$orderby={orderBy}&$skip={skip}&$top={top}");


        }

        public async Task<ItemApiResponse> GetItemsAsync(string orderBy, int skip)
        {
            return await _httpService.Get<ItemApiResponse>($"api/item?$count=true&$expand=Warehouse&$orderby={orderBy}&$skip={skip}");

        }


        public async Task<ItemReadDto> GetItemByIdAsync(int id)
        {
            return await _httpService.Get<ItemReadDto>($"api/item/{id}?$expand=Warehouse");


        }

        public async Task DeleteItemByIdAsync(int id)
        {
            //consider impact vs returning just status code
            await _httpService.Delete<HttpResponseMessage>($"api/item/{id}");
        }

        public async Task<HttpResponseMessage> CreateItemAsync(ItemCreateDto item)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/item", item);
        }

        public async Task EditItemAsync(int id, ItemUpdateDto item)
        {

            await _httpService.Put<HttpResponseMessage>($"api/item/{id}", item);
        }
    }
}
