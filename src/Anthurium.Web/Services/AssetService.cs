using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class AssetService : IAssetService
    {
        private IHttpService _httpService;

        public AssetService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<AssetApiResponse> GetAssetsAsync(string orderBy, int skip, int top)
        {
            return await _httpService.Get<AssetApiResponse>($"api/asset?$count=true&$expand=Vendor,Item,ClientInformation&$orderby={orderBy}&$skip={skip}&$top={top}");


        }
        public async Task<AssetApiResponse> GetAssetsByClientIdAsync(string orderBy, int skip, int top, int clientInformationId)
        {
            return await _httpService.Get<AssetApiResponse>($"api/asset?$count=true&$filter=ClientInformationId eq {clientInformationId}&$expand=Vendor,Item,ClientInformation&$orderby={orderBy}&$skip={skip}&$top={top}");

        }


        public async Task<AssetApiResponse> GetAssetsAsync(string orderBy, int skip)
        {
            return await _httpService.Get<AssetApiResponse>($"api/asset?$count=true&$expand=Vendor,Item,ClientInformation&$orderby={orderBy}&$skip={skip}");


        }


        public async Task<AssetReadDto> GetAssetByIdAsync(int id)
        {
            return await _httpService.Get<AssetReadDto>($"api/asset/{id}?$expand=Vendor,Item,ClientInformation");

        }

        public async Task DeleteAssetByIdAsync(int id)
        {
            //consider impact vs returning just status code
             await _httpService.Delete($"api/asset/{id}");
        }

        public async Task<HttpResponseMessage> CreateAssetAsync(AssetCreateDto asset)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/asset", asset);
        }

        public async Task EditAssetAsync(int id, AssetUpdateDto asset)
        {

            await _httpService.Put($"api/asset/{id}", asset);
        }
    }
}
