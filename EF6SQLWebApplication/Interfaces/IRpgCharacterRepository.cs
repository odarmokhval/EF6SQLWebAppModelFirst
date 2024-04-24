namespace EF6SQLWebApplication.Intergaces
{
    public interface IRpgCharacterRepository
    {
        void AddCharacter(RpgCharacter character);
        Task<IEnumerable<RpgCharacter>> GetAllCharacters();
        Task<RpgCharacter> GetCharacter(int id);
    }
}
