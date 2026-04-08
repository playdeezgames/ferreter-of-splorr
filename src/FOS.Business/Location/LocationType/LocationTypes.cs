namespace FOS.Business
{
    internal static class LocationTypes
    {
        internal static readonly string BLUE_ROOM = nameof(BLUE_ROOM);
        internal static readonly string LOFT = nameof(LOFT);
        internal static readonly string TOWN = nameof(TOWN);
        internal readonly static IReadOnlyDictionary<string, ILocationType> All =
            new List<ILocationType>
            {
                new BlueRoomLocationType(),
                new LoftLocationType(),
                new TownLocationType()
            }.ToDictionary(x => x.Identifier, x => x);

    }
}
