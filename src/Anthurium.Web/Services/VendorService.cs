using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class VendorService : IVendorService
    {
        private IHttpService _httpService;

        public VendorService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<VendorApiResponse> GetVendorsAsync(string orderBy, int skip, int top)
        {
           return await _httpService.Get<VendorApiResponse>($"api/vendor?$count=true&$orderby={orderBy}&$skip={skip}&$top={top}");
        }


        public async Task<VendorApiResponse> GetVendorsAsync(string orderBy, int skip)
        {
           return await _httpService.Get<VendorApiResponse>($"api/vendor?$count=true&$orderby={orderBy}&$skip={skip}");

        }

        public async Task<VendorReadDto> GetVendorByIdAsync(int id)
        {
           return await _httpService.Get<VendorReadDto>($"api/vendor/{id}");

        }

        public async Task<HttpResponseMessage> DeleteVendorByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpService.Delete<HttpResponseMessage>($"api/vendor/{id}");
        }

        public async Task<HttpResponseMessage> CreateVendorAsync(VendorCreateDto vendor)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/vendor", vendor);
        }

        public async Task<HttpResponseMessage> EditVendorAsync(int id, VendorUpdateDto vendor)
        {

            return await _httpService.Put<HttpResponseMessage>($"api/vendor/{id}", vendor);
        }
    }
}
