using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{

    public class SqlServerWarehouseRepository : ISqlServerWarehouseRepository
    {
        private readonly AnthuriumContext _context;

        public SqlServerWarehouseRepository(AnthuriumContext context)
        {
            _context = context;
        }

        public Warehouse WarehouseById(int Id)
        {
            return _context.Warehouses.FirstOrDefault(p => p.WarehouseId == Id);
        }



        public IEnumerable<Warehouse> GetWarehouse()
        {
            return _context.Warehouses.ToList();
        }





        public void NewWarehouse(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            _context.Warehouses.Add(warehouse);
        }

        public void RemoveWarehouse(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            _context.Warehouses.Remove(warehouse);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            //nothing
        }
    }
}
