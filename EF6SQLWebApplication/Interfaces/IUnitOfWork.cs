using EF6SQLWebApplication.Intergaces;

namespace EF6SQLWebApplication.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRpgCharacterRepository RpgCharacterRepository { get; }
        IRpgCharacterInventoryRepository RpgCharacterInventoryRepository { get; }
        Task<bool> SaveAsync();
    }
}
