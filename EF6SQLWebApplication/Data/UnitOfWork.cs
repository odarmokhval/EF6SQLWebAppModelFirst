using EF6SQLWebApplication.Data.Repo;
using EF6SQLWebApplication.Interfaces;
using EF6SQLWebApplication.Intergaces;

namespace EF6SQLWebApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IRpgCharacterRepository _rpgCharacterRepository;
        private IRpgCharacterInventoryRepository _rpgCharacterInventoryRepository;
        public UnitOfWork(DataContext dataContext,
               IRpgCharacterRepository rpgCharacterRepository,
               IRpgCharacterInventoryRepository rpgCharacterInventoryRepository)
        {
            _dataContext = dataContext;
            _rpgCharacterRepository = rpgCharacterRepository;
            _rpgCharacterInventoryRepository = rpgCharacterInventoryRepository;
        }

        public IRpgCharacterRepository RpgCharacterRepository
        {
            get
            {
                return (RpgCharacterRepository)(_rpgCharacterRepository ??= new RpgCharacterRepository(_dataContext));
            }
        }

        public IRpgCharacterInventoryRepository RpgCharacterInventoryRepository
        {
            get
            {
                return (RpgCharacterInventoryRepository)(_rpgCharacterInventoryRepository ??= new RpgCharacterInventoryRepository(_dataContext));
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
