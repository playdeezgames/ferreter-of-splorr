namespace FOS.Business
{
    internal static class LocationTypes
    {
        internal static readonly string BLUE_ROOM = nameof(BLUE_ROOM);
        internal static readonly string ROOM = nameof(ROOM);
        internal readonly static IReadOnlyDictionary<string, ILocationType> All =
            new List<ILocationType> 
            { 
                new BlueRoomLocationType(),
                new RoomLocationType()
            }.ToDictionary(x => x.Identifier, x => x);

    }
}
