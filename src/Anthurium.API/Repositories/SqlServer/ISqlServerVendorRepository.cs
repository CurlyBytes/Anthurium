using Anthurium.Shared.Models;
using System.Collections.Generic;

namespace Anthurium.API.Repositories.SqlServer
{
    public interface ISqlServerVendorRepository
    {
        IEnumerable<Vendor> GetVendor();
        void NewVendor(Vendor warehouse);
        void RemoveVendor(Vendor warehouse);
        bool SaveChanges();
        void UpdateVendor(Vendor warehouse);
        Vendor VendorById(int Id);
    }
}