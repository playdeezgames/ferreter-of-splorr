namespace FOS.Business
{
    internal static class FeatureTypes
    {
        internal static readonly string BED = nameof(BED);
        internal readonly static IReadOnlyDictionary<string, IFeatureType> All =
            new List<IFeatureType>
            {
                new BedFeatureType()
            }.ToDictionary(x => x.Identifier, x => x);

    }
}
