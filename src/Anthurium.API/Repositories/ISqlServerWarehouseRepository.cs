using Anthurium.Shared.Models;
using System.Collections.Generic;

namespace Anthurium.API.Repositories
{
    public interface ISqlServerWarehouseRepository
    {
        IEnumerable<Warehouse> GetWarehouse();
        void NewWarehouse(Warehouse warehouse);
        void RemoveWarehouse(Warehouse warehouse);
        bool SaveChanges();
        void UpdateWarehouse(Warehouse warehouse);
        Warehouse WarehouseById(int Id);
    }
}
