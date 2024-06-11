using EF6SQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplication.Interfaces
{
    public interface IDataContext : IDisposable
    {
        DbSet<RpgCharacter> RpgCharacters { get; }
        DbSet<RpgCharacterInventory> RpgCharacterInventory { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
