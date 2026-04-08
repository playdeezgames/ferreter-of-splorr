namespace FOS.Business
{
    internal class RoadRouteType : IRouteType
    {
        public string Identifier => RouteTypes.ROAD;

        public void Initialize(IRoute route)
        {
        }
    }
}