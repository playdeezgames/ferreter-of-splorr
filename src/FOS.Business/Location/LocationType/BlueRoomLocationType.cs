namespace FOS.Business
{
    internal class BlueRoomLocationType : ILocationType
    {
        public string Identifier => LocationTypes.BLUE_ROOM;

        public void Initialize(ILocation location)
        {
        }
    }
}
