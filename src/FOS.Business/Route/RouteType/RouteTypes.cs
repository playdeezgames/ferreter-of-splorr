namespace FOS.Business
{
    internal static class RouteTypes
    {
        internal static readonly string LADDER = nameof(LADDER);
        internal static readonly string ROAD = nameof(ROAD);
        internal static readonly string DOOR = nameof(DOOR);
        internal readonly static IReadOnlyDictionary<string, IRouteType> All =
            new List<IRouteType>
            {
                new LadderRouteType(),
                new RoadRouteType(),
                new DoorRouteType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
