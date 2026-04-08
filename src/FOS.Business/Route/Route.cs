using FOS.Data;

namespace FOS.Business
{
    internal class Route : IRoute
    {
        private readonly WorldData _data;
        private readonly Guid _routeId;
        private readonly Direction _direction;
        private RouteData RouteData => _data.Routes[_routeId];
        internal Route(WorldData data, Direction direction, Guid routeId)
        {
            _data = data;
            _routeId = routeId;
            _direction = direction;
        }

        public Guid RouteId => _routeId;

        public Direction Direction => _direction;

        public string Name => RouteData.Name;

        public ILocation Destination => new Location(_data, RouteData.ToLocationId);
    }
}
