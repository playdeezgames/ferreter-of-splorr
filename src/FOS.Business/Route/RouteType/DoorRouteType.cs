namespace FOS.Business
{
    internal class DoorRouteType : IRouteType
    {
        public string Identifier => RouteTypes.DOOR;

        public void Initialize(IRoute route)
        {
        }
    }
}