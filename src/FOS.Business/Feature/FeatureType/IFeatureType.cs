namespace FOS.Business
{
    internal interface IFeatureType
    {
        string Identifier { get; }
        void Initialize(IFeature feature);
    }
}