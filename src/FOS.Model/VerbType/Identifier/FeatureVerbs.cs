namespace FOS.Model
{
    internal static class FeatureVerbs
    {
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new SearchFeatureVerbType(),
                new ExamineFeatureVerbType(),
                new BlurFeatureVerbType()
            ];
    }
}
