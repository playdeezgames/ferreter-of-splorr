namespace FOS.Business
{
    internal static class LocationTypes
    {
        internal static readonly string BLUE_ROOM = nameof(BLUE_ROOM);
        internal readonly static IReadOnlyDictionary<string, ILocationType> All =
            new List<ILocationType> { new BlueRoomLocationType() }.ToDictionary(x => x.Identifier, x => x);

    }
}
