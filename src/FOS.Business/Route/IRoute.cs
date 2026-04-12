using FOS.Data;

namespace FOS.Business
{
    public interface IRoute
    {
        Guid RouteId { get; }
        Direction Direction { get; }
        string Name { get; }
        ILocation Destination { get; }

        object GetDirectionName();
    }
}
