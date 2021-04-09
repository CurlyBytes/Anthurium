using Anthurium.API.Data;
using Anthurium.Shared.Models;
using Microsoft.EntityFrameworkCore;
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
 


            var test=  _context.Items.Include(s => s.Warehouse)
                     .Where(s => s.ItemId == Id)
                     .FirstOrDefault<Item>();
            return test;
        }



        public IEnumerable<Item> GetItem()
        {
            var test= _context.Items
                         .Include(x => x.Warehouse).ToList();

            return test;
        }

  




        public void NewItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Remove(item);
        }



        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateItem(Item item)
        {
            //nothing
        }
    }
}
