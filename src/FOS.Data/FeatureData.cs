namespace FOS.Data
{
    public class FeatureData : EntityData
    {
        public required string Name { get; set; }
        public required Guid LocationId { get; set; }
        public Dictionary<string, Guid> TriggerIds { get; set; } = [];
    }
}