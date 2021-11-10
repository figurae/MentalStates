using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalStates.Models
{
    public class ItemRepository : IItemRepository
    {
        public Task<Item> AddItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteItem(int itemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItem()
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItem(int itemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> UpdateItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}