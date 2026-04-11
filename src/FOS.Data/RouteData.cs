namespace FOS.Data
{
    public class RouteData
    {
        public required string Name { get; set; }
        public required Guid ToLocationId { get; set; }
    }
}
