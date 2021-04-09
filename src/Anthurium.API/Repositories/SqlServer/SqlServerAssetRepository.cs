using Anthurium.API.Data;
using Anthurium.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
    public class SqlServerAssetRepository : ISqlServerAssetRepository
    {
        private readonly AnthuriumContext _context;

        public SqlServerAssetRepository(AnthuriumContext context)
        {
            _context = context;
        }

        public Asset AssetById(int Id)
        {
            return _context.Assets
                      .Include(c => c.ClientInformation)
                .Include(i => i.Item)
                .Include(v => v.Vendor)
                .FirstOrDefault(p => p.AssetId == Id);
        }



        public IEnumerable<Asset> GetAsset()
        {
            var test= _context.Assets

                .Include(c => c.ClientInformation)
                .Include(i => i.Item)
                .Include(v => v.Vendor)
                .ToList();
            return test;
        }





        public void NewAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            _context.Assets.Add(asset);
        }

        public void RemoveAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            _context.Assets.Remove(asset);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateAsset(Asset asset)
        {
            //nothing
        }
    }
}
