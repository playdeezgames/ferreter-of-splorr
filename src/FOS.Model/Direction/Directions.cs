namespace FOS.Model
{
    public static class Directions
    {
        internal static readonly string NORTH = nameof(NORTH);
        internal static readonly string EAST = nameof(EAST);
        internal static readonly string SOUTH = nameof(SOUTH);
        internal static readonly string WEST = nameof(WEST);
        internal static readonly string UP = nameof(UP);
        internal static readonly string DOWN = nameof(DOWN);
        internal static readonly string IN = nameof(IN);
        internal static readonly string OUT = nameof(OUT);
        internal static readonly string PORTAL = nameof(PORTAL);
        internal static IReadOnlyDictionary<string, IDirectionType> All =
            new List<IDirectionType>
            {
                new NorthDirectionType(),
                new EastDirectionType(),
                new SouthDirectionType(),
                new WestDirectionType(),
                new UpDirectionType(),
                new DownDirectionType(),
                new InDirectionType(),
                new OutDirectionType(),
                new PortalDirectionType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
