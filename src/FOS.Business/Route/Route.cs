using FOS.Data;

namespace FOS.Business
{
    internal class Route(
        WorldData data,
        IGrimoire grimoire,
        string direction,
        Guid routeId) : IRoute
    {
        private RouteData RouteData => data.Routes[routeId];

        public Guid RouteId => routeId;

        public string Direction => direction;

        public string Name => RouteData.Name;

        public ILocation Destination => new Location(data, grimoire, RouteData.ToLocationId);

        public object GetDirectionName()
        {
            return grimoire.GetDirectionName(this.Direction.ToString());
        }

        public bool Allows(ICharacter character)
        {
            return grimoire.DoesRouteAllowCharacter(this, character);
        }
    }
}
