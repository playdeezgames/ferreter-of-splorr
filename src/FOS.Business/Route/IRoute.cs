namespace FOS.Business
{
    public interface IRoute
    {
        Guid RouteId { get; }
        string Direction { get; }
        string Name { get; }
        ILocation Destination { get; }

        object GetDirectionName();
    }
}
