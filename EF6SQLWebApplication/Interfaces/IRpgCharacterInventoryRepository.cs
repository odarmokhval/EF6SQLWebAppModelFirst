using EF6SQLWebApplication.Models;

namespace EF6SQLWebApplication.Intergaces
{
    public interface IRpgCharacterInventoryRepository
    {
        void AddItemToInventory(RpgCharacterInventory item);
        Task<IEnumerable<RpgCharacterInventory>> GetAllItems();
        Task<RpgCharacterInventory> GetItem(int id);
    }
}
