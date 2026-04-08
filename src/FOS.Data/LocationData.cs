namespace FOS.Data
{
    public class LocationData : EntityData
    {
        public required string LocationType { get; set; }
        public required string Name { get; set; }
        public HashSet<Guid> CharacterIds { get; set; } = [];
        public Dictionary<Direction, Guid> RouteIds { get; set; } = [];
    }
}
