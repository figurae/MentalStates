using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalStates.Models
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItem();
        Task<Item>              GetItem(int itemId);
        Task<Item>              AddItem(Item item);
        Task<Item>              UpdateItem(Item item);
        void                    DeleteItem(int itemId);

    }
}