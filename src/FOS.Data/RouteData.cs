namespace FOS.Data
{
    public class RouteData : EntityData
    {
        public required string Name { get; set; }
        public required Guid ToLocationId { get; set; }
    }
}
