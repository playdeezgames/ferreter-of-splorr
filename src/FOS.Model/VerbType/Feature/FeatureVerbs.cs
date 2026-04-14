namespace FOS.Model
{
    internal static class FeatureVerbs
    {
        internal readonly static string SEARCH_FEATURE = nameof(SEARCH_FEATURE);
        internal readonly static string BLUR_FEATURE = nameof(BLUR_FEATURE);
        internal readonly static string EXAMINE_FEATURE = nameof(EXAMINE_FEATURE);
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new SearchFeatureVerbType(),
                new ExamineFeatureVerbType(),
                new BlurFeatureVerbType()
            ];
    }
}
