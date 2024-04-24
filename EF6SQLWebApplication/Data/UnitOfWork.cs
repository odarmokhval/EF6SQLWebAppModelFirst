using EF6SQLWebApplication.Data.Repo;
using EF6SQLWebApplication.Interfaces;
using EF6SQLWebApplication.Intergaces;

namespace EF6SQLWebApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IRpgCharacterRepository RpgCharacterRepository => 
            new RpgCharacterRepository(_dataContext);

        public IRpgCharacterInventoryRepository RpgCharacterInventoryRepository =>
            new RpgCharacterInventoryRepository(_dataContext);

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
