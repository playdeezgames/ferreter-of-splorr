namespace FOS.Data
{
    public class RouteData
    {
        public required string RouteType { get; set; }
        public required string Name { get; set; }
        public required Guid ToLocationId { get; set; }
    }
}
