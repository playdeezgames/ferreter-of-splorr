namespace FOS.Data
{
    public class WorldData
    {
        public Dictionary<Guid, CharacterData> Characters { get; set; } = [];
        public Guid? AvatarCharacterId { get; set; }
        public Dictionary<Guid, LocationData> Locations { get; set; } = [];
        public Dictionary<Guid, RouteData> Routes { get; set; } = [];
        public Dictionary<Guid, FeatureData> Features { get; set; } = [];
        public Dictionary<Guid, TriggerData> Triggers { get; set; } = [];
        public Dictionary<Guid, InventoryData> Inventories { get; set; } = [];
        public Dictionary<Guid, ItemData> Items { get; set; } = [];
        public List<MessageData> Messages { get; set; } = [];
    }
}
