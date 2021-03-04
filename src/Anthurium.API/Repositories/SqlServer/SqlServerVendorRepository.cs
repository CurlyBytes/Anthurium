using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
    public class SqlServerVendorRepository : ISqlServerVendorRepository
    {
     
            private readonly AnthuriumContext _context;

            public SqlServerVendorRepository(AnthuriumContext context)
            {
                _context = context;
            }

            public Vendor VendorById(int Id)
            {
                return _context.Vendors.FirstOrDefault(p => p.VendorId == Id);
            }



            public IEnumerable<Vendor> GetVendor()
            {
                return _context.Vendors.ToList();
            }





            public void NewVendor(Vendor Vendor)
            {
                if (Vendor == null)
                {
                    throw new ArgumentNullException(nameof(Vendor));
                }

                _context.Vendors.Add(Vendor);
            }

            public void RemoveVendor(Vendor Vendor)
            {
                if (Vendor == null)
                {
                    throw new ArgumentNullException(nameof(Vendor));
                }

                _context.Vendors.Remove(Vendor);
            }



            public bool SaveChanges()
            {
                return (_context.SaveChanges()) >= 0;
            }

            public void UpdateVendor(Vendor Vendor)
            {
                //nothing
            }
    }
    
}
