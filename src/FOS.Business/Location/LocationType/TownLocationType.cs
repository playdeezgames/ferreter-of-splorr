namespace FOS.Business
{
    internal class TownLocationType : ILocationType
    {
        public string Identifier => LocationTypes.TOWN;

        public void Initialize(ILocation location)
        {
        }
    }
}