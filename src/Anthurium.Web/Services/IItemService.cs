using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services {
  public interface IItemService {
    Task<HttpResponseMessage> CreateItemAsync(ItemCreateDto item);
    Task DeleteItemByIdAsync(int id);
    Task EditItemAsync(int id, ItemUpdateDto item);
    Task<ItemReadDto> GetItemByIdAsync(int id);
    Task<ItemApiResponse> GetItemsAsync(string orderBy, int skip);
    Task<ItemApiResponse> GetItemsAsync(string orderBy, int skip, int top);
  }
}