using EF6SQLWebApplication.Intergaces;
using EF6SQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplication.Data.Repo
{
    public class RpgCharacterInventoryRepository : IRpgCharacterInventoryRepository
    {
        private readonly DataContext _dataContext;
        public RpgCharacterInventoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddItemToInventory(RpgCharacterInventory item)
        {
            _dataContext.RpgCharacterInventory.Add(item);
        }

        public async Task<IEnumerable<RpgCharacterInventory>> GetAllItems()
        {
            return await _dataContext.RpgCharacterInventory.ToListAsync();
        }

        public async Task<RpgCharacterInventory> GetItem(int id)
        {
            return await _dataContext.RpgCharacterInventory.FindAsync(id);
        }
    }
}
