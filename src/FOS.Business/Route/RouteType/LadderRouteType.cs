namespace FOS.Business
{
    internal class LadderRouteType : IRouteType
    {
        public string Identifier => RouteTypes.LADDER;

        public void Initialize(IRoute route)
        {
        }
    }
}