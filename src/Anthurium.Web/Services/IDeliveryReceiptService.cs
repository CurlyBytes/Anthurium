using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
public interface IDeliveryReceiptService
{
    Task<HttpResponseMessage> CreateDeliveryReceiptAsync(DeliveryReceiptCreateDto deliveryReceipt);
    Task DeleteDeliveryReceiptByIdAsync(int id);
    Task EditDeliveryReceiptAsync(int id, DeliveryReceiptUpdateDto deliveryReceipt);
    Task<DeliveryReceiptReadDto> GetDeliveryReceiptByIdAsync(int id);
    Task<DeliveryReceiptApiResponse> GetDeliveryReceiptsAsync(string orderBy, int skip);
    Task<DeliveryReceiptApiResponse> GetDeliveryReceiptsAsync(string orderBy, int skip, int top);
    Task<DeliveryReceiptApiResponse> GetDeliveryReceiptsByClientIdAsync(string orderBy, int skip, int top, int clientInformationId);
}
}