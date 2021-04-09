using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public interface IClientInformationService
    {
        Task<HttpResponseMessage> CreateClientInformationAsync(ClientInformationCreateDto clientinformation);
        Task DeleteClientInformationByIdAsync(int id);
        Task EditClientInformationAsync(int id, ClientInformationUpdateDto clientinformation);
        Task<ClientInformationReadDto> GetClientInformationByIdAsync(int id);
        Task<ClientInformationApiResponse> GetClientInformationsAsync(string orderBy, int skip);
        Task<ClientInformationApiResponse> GetClientInformationsAsync(string orderBy, int skip, int top);
    }
}