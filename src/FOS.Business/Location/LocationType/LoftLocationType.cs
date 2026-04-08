namespace FOS.Business
{
    internal class LoftLocationType : ILocationType
    {
        public string Identifier => LocationTypes.LOFT;

        public void Initialize(ILocation location)
        {
        }
    }
}