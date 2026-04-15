namespace FOS.Data
{
    public class LocationData : InventoryEntityData
    {
        public required string Name { get; set; }
        public HashSet<Guid> CharacterIds { get; set; } = [];
        public Dictionary<string, Guid> RouteIds { get; set; } = [];
        public HashSet<Guid> FeatureIds { get; set; } = [];
        public Dictionary<string, Guid> TriggerIds = [];
    }
}
