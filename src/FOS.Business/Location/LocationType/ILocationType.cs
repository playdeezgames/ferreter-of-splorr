namespace FOS.Business
{
    internal interface ILocationType
    {
        string Identifier { get; }
        void Initialize(ILocation location);
    }
}
