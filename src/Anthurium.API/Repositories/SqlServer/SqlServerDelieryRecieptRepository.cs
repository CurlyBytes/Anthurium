using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
public class SqlServerDeliveryReceiptRepository : ISqlServerDeliveryReceiptRepository
{
    private readonly AnthuriumContext _context;

    public SqlServerDeliveryReceiptRepository(AnthuriumContext context)
    {
        _context = context;
    }

    public DeliveryReceipt DeliveryReceiptById(int Id)
    {
        // return _context.DeliveryReceipts.FirstOrDefault(p => p.DeliveryReceiptId == Id);
        return _context.DeliveryReceipts
               .Include(c => c.DeliveryReceiptDetails)
               .Include(i => i.ClientInformation)
               .FirstOrDefault(p => p.DeliveryReceiptId == Id);
    }



    public IEnumerable<DeliveryReceipt> GetDeliveryReceipt()
    {


        var test = _context.DeliveryReceipts

                   .Include(c => c.ClientInformation)

                   .Include(jq => jq.JobQuotation)
                   .Include(dr => dr.DeliveryReceiptDetails)
                   .ToList();
        return test;
    }





    public void NewDeliveryReceipt(DeliveryReceipt deliveryReceipt)
    {
        if (deliveryReceipt == null)
        {
            throw new ArgumentNullException(nameof(deliveryReceipt));
        }

        _context.DeliveryReceipts.Add(deliveryReceipt);
    }

    public void RemoveDeliveryReceipt(DeliveryReceipt deliveryReceipt)
    {
        if (deliveryReceipt == null)
        {
            throw new ArgumentNullException(nameof(deliveryReceipt));
        }

        _context.DeliveryReceipts.Remove(deliveryReceipt);
    }



    public bool SaveChanges()
    {
        return (_context.SaveChanges()) >= 0;
    }

    public void UpdateDeliveryReceipt(DeliveryReceipt deliveryReceipt)
    {
        //nothing
    }
}
}
