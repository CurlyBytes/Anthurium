using Anthurium.Shared.Models;
using System.Collections.Generic;

namespace Anthurium.API.Repositories.SqlServer
{
    public interface ISqlServerDeliveryReceiptRepository
    {
        IEnumerable<DeliveryReceipt> GetDeliveryReceipt();
        void NewDeliveryReceipt(DeliveryReceipt warehouse);
        void RemoveDeliveryReceipt(DeliveryReceipt warehouse);
        bool SaveChanges();
        void UpdateDeliveryReceipt(DeliveryReceipt warehouse);
        DeliveryReceipt DeliveryReceiptById(int Id);
    }
}