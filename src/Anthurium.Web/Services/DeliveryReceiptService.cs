using Anthurium.API.Dtos;
using Anthurium.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anthurium.Web.Services
{
    public class DeliveryReceiptService : IDeliveryReceiptService
    {
        private IHttpService _httpService;

        public DeliveryReceiptService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<DeliveryReceiptApiResponse> GetDeliveryReceiptsAsync( string orderBy, int skip, int top)
        {


            //string concatTables = string.Join(",", tables);
            return await _httpService.Get<DeliveryReceiptApiResponse>($"api/deliveryreceipt?$count=true&$expand=DeliveryReceiptDetails&$orderby={orderBy}&$skip={skip}&$top={top}");


        }
        public async Task<DeliveryReceiptApiResponse> GetDeliveryReceiptsByClientIdAsync(string orderBy, int skip, int top, int clientInformationId)
        {
            return await _httpService.Get<DeliveryReceiptApiResponse>($"api/deliveryreceipt?$count=true&$filter=ClientInformationId eq {clientInformationId}&$expand=Delivery,Item,ClientInformation&$orderby={orderBy}&$skip={skip}&$top={top}");

        }


        public async Task<DeliveryReceiptApiResponse> GetDeliveryReceiptsAsync(string orderBy, int skip)
        {
            return await _httpService.Get<DeliveryReceiptApiResponse>($"api/deliveryreceipt?$count=true&$expand=Vendor,Item,ClientInformation&$orderby={orderBy}&$skip={skip}");


        }


        public async Task<DeliveryReceiptReadDto> GetDeliveryReceiptByIdAsync(int id)
        {
            return await _httpService.Get<DeliveryReceiptReadDto>($"api/deliveryreceipt/{id}?$expand=Vendor,Item,ClientInformation");

        }

        public async Task<HttpResponseMessage> DeleteDeliveryReceiptByIdAsync(int id)
        {
            //consider impact vs returning just status code
            return await _httpService.Delete<HttpResponseMessage>($"api/deliveryreceipt/{id}");
        }

        public async Task<HttpResponseMessage> CreateDeliveryReceiptAsync(DeliveryReceiptCreateDto deliveryReceipt)
        {

            return await _httpService.Post<HttpResponseMessage>($"api/deliveryreceipt", deliveryReceipt);
        }

        public async Task<HttpResponseMessage> EditDeliveryReceiptAsync(int id, DeliveryReceiptUpdateDto deliveryReceipt)
        {

            return await _httpService.Put<HttpResponseMessage>($"api/deliveryreceipt/{id}", deliveryReceipt);
        }
    }
}
