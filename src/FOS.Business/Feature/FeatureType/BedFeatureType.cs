namespace FOS.Business
{
    internal class BedFeatureType : IFeatureType
    {
        public string Identifier => FeatureTypes.BED;

        public void Initialize(IFeature feature)
        {
        }
    }
}