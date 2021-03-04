using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
    public class SqlServerDeliveryReceiptDetailsRepository : ISqlServerDeliveryReceiptDetailsRepository
    {
        private readonly AnthuriumContext _context;

        public SqlServerDeliveryReceiptDetailsRepository(AnthuriumContext context)
        {
            _context = context;
        }

        public DeliveryReceiptDetails DeliveryReceiptDetailsById(int Id)
        {
            return _context.DeliveryReceiptDetailss.FirstOrDefault(p => p.DeliveryReceiptDetailsId == Id);
        }



        public IEnumerable<DeliveryReceiptDetails> GetDeliveryReceiptDetails()
        {
            return _context.DeliveryReceiptDetailss.ToList();
        }





        public void NewDeliveryReceiptDetails(DeliveryReceiptDetails deliveryReceiptDetails)
        {
            if (deliveryReceiptDetails == null)
            {
                throw new ArgumentNullException(nameof(deliveryReceiptDetails));
            }

            _context.DeliveryReceiptDetailss.Add(deliveryReceiptDetails);
        }

        public void RemoveDeliveryReceiptDetails(DeliveryReceiptDetails deliveryReceiptDetails)
        {
            if (deliveryReceiptDetails == null)
            {
                throw new ArgumentNullException(nameof(deliveryReceiptDetails));
            }

            _context.DeliveryReceiptDetailss.Remove(deliveryReceiptDetails);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateDeliveryReceiptDetails(DeliveryReceiptDetails deliveryReceiptDetails)
        {
            //nothing
        }
    }
}
