using EF6SQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

        public DbSet<RpgCharacter> RpgCharacters => Set<RpgCharacter>();
        public DbSet<RpgCharacterInventory> RpgCharacterInventory => Set<RpgCharacterInventory>();
    }
}
