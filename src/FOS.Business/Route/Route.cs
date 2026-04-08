using FOS.Data;

namespace FOS.Business
{
    internal class Route : IRoute
    {
        private readonly WorldData _data;
        private readonly Guid _routeId;
        internal Route(WorldData data, Guid routeId)
        {
            _data = data;
            _routeId = routeId;
        }

        public Guid RouteId => _routeId;
    }
}
