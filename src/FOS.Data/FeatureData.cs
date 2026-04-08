namespace FOS.Data
{
    public class FeatureData : EntityData
    {
        public required string FeatureType { get; set; }
        public required string Name { get; set; }
        public required Guid LocationId { get; set; }
    }
}