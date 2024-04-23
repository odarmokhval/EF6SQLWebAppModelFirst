namespace EF6SQLWebApplication.Models
{
    public class RpgCharacterInventory
    {
        public int Id { get; set; }
        public int RpgCharacterId { get; set; }
        public RpgCharacter? RpgCharacter { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
