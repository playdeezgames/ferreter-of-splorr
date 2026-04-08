namespace FOS.Business
{
    internal class RoomLocationType : ILocationType
    {
        public string Identifier => LocationTypes.ROOM;

        public void Initialize(ILocation location)
        {
        }
    }
}