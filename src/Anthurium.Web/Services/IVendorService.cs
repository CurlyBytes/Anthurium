using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IVendorService
    {
        Task<HttpResponseMessage> CreateVendorAsync(VendorCreateDto vendor);
        Task<HttpResponseMessage> DeleteVendorByIdAsync(int id);
        Task<HttpResponseMessage> EditVendorAsync(int id, VendorUpdateDto vendor);
        Task<VendorReadDto> GetVendorByIdAsync(int id);
        Task<VendorApiResponse> GetVendorsAsync(string orderBy, int skip);
        Task<VendorApiResponse> GetVendorsAsync(string orderBy, int skip, int top);
    }
}