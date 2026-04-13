namespace FOS.Data
{
    public class CharacterData : InventoryEntityData
    {
        public required string Direction { get; set; }
        public required Guid LocationId { get; set; }
        public required string Name { get; set; }
        public Guid? FocusFeatureId { get; set; }
        public Guid? FocusItemId { get; set; }
        public Guid? FocusCharacterId { get; set; }
    }
}
