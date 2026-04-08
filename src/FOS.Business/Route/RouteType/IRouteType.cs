namespace FOS.Business
{
    internal interface IRouteType
    {
        string Identifier { get; }
        void Initialize(IRoute route);
    }
}