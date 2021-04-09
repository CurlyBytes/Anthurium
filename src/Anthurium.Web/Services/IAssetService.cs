using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IAssetService
    {
        Task<HttpResponseMessage> CreateAssetAsync(AssetCreateDto asset);
        Task DeleteAssetByIdAsync(int id);
        Task EditAssetAsync(int id, AssetUpdateDto asset);
        Task<AssetReadDto> GetAssetByIdAsync(int id);
        Task<AssetApiResponse> GetAssetsAsync(string orderBy, int skip);
        Task<AssetApiResponse> GetAssetsAsync(string orderBy, int skip, int top);
        Task<AssetApiResponse> GetAssetsByClientIdAsync(string orderBy, int skip, int top, int clientInformationId);
    }
}