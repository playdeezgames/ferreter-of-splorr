namespace FOS.Business
{
    internal static class RouteTypes
    {
        internal static readonly string LADDER = nameof(LADDER);
        internal readonly static IReadOnlyDictionary<string, IRouteType> All =
            new List<IRouteType>
            {
                new LadderRouteType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
