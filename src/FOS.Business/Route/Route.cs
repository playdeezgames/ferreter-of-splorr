using FOS.Data;

namespace FOS.Business
{
    internal class Route(
        WorldData data,
        IGrimoire grimoire,
        string direction,
        Guid routeId) : Entity<RouteData>(data, grimoire), IRoute
    {
        public Guid RouteId => routeId;

        public string Direction => direction;

        public string Name => GetEntityData().Name;

        public ILocation Destination => new Location(Data, Grimoire, GetEntityData().ToLocationId);

        internal override RouteData GetEntityData()
        {
            return Data.Routes[RouteId];
        }
    }
}
