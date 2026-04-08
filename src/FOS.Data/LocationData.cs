namespace FOS.Data
{
    public class LocationData
    {
        public required string LocationType { get; set; }
        public required string Name { get; set; }
        public HashSet<Guid> CharacterIds { get; set; } = [];
        public Dictionary<Direction, Guid> RouteIds { get; set; } = [];
    }
}
