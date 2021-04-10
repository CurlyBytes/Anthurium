using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services {
  public interface IWarehouseService {
    Task<HttpResponseMessage> CreateWarehouseAsync(
        WarehouseCreateDto warehouse);
    Task DeleteWarehouseByIdAsync(int id);
    Task EditWarehouseAsync(int id, WarehouseUpdateDto warehouse);
    Task<WarehouseReadDto> GetWarehouseByIdAsync(int id);
    Task<WarehouseApiResponse> GetWarehousesAsync(string orderBy, int skip);
    Task<WarehouseApiResponse> GetWarehousesAsync(string orderBy, int skip,
                                                  int top);
  }
}
