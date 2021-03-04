using Anthurium.Shared.Models;
using System.Collections.Generic;

namespace Anthurium.API.Repositories.SqlServer
{
    public interface ISqlServerAssetRepository
    {
        IEnumerable<Asset> GetAsset();
        void NewAsset(Asset warehouse);
        void RemoveAsset(Asset warehouse);
        bool SaveChanges();
        void UpdateAsset(Asset warehouse);
        Asset AssetById(int Id);
    }
}