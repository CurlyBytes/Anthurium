using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
    public interface ISqlServerDeliveryReceiptDetailsRepository
    {
        IEnumerable<DeliveryReceiptDetails> GetDeliveryReceiptDetails();
        void NewDeliveryReceiptDetails(DeliveryReceiptDetails deliveryReceiptDetails);
        void RemoveDeliveryReceiptDetails(DeliveryReceiptDetails deliveryReceiptDetails);
        bool SaveChanges();
        void UpdateDeliveryReceiptDetails(DeliveryReceiptDetails deliveryReceiptDetails);
        DeliveryReceiptDetails DeliveryReceiptDetailsById(int Id);
    }
}
