using Anthurium.API.Data;
using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Repositories.SqlServer
{
    public class SqlServerItemRepository  : ISqlServerItemRepository
    {
        private readonly AnthuriumContext _context;

        public SqlServerItemRepository(AnthuriumContext context)
        {
            _context = context;
        }

        public Item ItemById(int Id)
        {
            return _context.Items.FirstOrDefault(p => p.ItemId == Id);
        }



        public IEnumerable<Item> GetItem()
        {
            return _context.Items.ToList();
        }


  


        public void NewItem(Item warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            _context.Items.Add(warehouse);
        }

        public void RemoveItem(Item warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            _context.Items.Remove(warehouse);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateItem(Item warehouse)
        {
            //nothing
        }
    }
}
