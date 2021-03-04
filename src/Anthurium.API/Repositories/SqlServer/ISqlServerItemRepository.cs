using Anthurium.Shared.Models;
using System.Collections.Generic;

namespace Anthurium.API.Repositories.SqlServer
{
    public interface ISqlServerItemRepository
    {
        IEnumerable<Item> GetItem();
        void NewItem(Item warehouse);
        void RemoveItem(Item warehouse);
        bool SaveChanges();
        void UpdateItem(Item warehouse);
        Item ItemById(int Id);
    }
}