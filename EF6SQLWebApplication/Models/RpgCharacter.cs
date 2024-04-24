using EF6SQLWebApplication.Models;

namespace EF6SQLWebApplication
{
    public class RpgCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CharacterClass { get; set; }
        public int HitPoints { get; set; } = 100;
    }
}
