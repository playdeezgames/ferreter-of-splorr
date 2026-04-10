namespace FOS.Data
{
    public class CharacterData : InventoryEntityData
    {
        public required string CharacterType { get; set; }
        public required Direction Direction { get; set; }
        public required Guid LocationId { get; set; }
        public Guid? FeatureId { get; set; }
    }
}
