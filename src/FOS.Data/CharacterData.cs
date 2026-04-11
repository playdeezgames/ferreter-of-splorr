namespace FOS.Data
{
    public class CharacterData : InventoryEntityData
    {
        public required Direction Direction { get; set; }
        public required Guid LocationId { get; set; }
        public Guid? FeatureId { get; set; }
        public Guid? ItemId { get; set; }
    }
}
