namespace FOS.Business
{
    public interface IRoute : IEntity
    {
        Guid RouteId { get; }
        string Direction { get; }
        string Name { get; }
        ILocation Destination { get; }
    }
}
