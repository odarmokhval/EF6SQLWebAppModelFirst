using EF6SQLWebApplication.Interfaces;
using EF6SQLWebApplication.Intergaces;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplication.Data.Repo
{
    public class RpgCharacterRepository : IRpgCharacterRepository
    {
        private readonly IDataContext _dataContext;
        public RpgCharacterRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddCharacter(RpgCharacter character)
        {
            _dataContext.RpgCharacters.Add(character);
        }

        public async Task<IEnumerable<RpgCharacter>> GetAllCharacters()
        {
            return await _dataContext.RpgCharacters.ToListAsync();
        }

        public async Task<RpgCharacter> GetCharacter(int id)
        {
            return await _dataContext.RpgCharacters.FindAsync(id);
        }
    }
}
