namespace FOS.Business
{
    internal static class RouteTypes
    {
        internal static readonly string DOOR = nameof(DOOR);
        internal readonly static IReadOnlyDictionary<string, IRouteType> All =
            new List<IRouteType>
            {
                new DoorRouteType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
