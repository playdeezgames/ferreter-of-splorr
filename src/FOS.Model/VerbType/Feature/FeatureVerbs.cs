namespace FOS.Model
{
    internal static class FeatureVerbs
    {
        private static string GetName(string name) => $"{nameof(FeatureVerbs)}.{name}";
        internal readonly static string SEARCH_FEATURE = GetName(nameof(SEARCH_FEATURE));
        internal readonly static string BLUR_FEATURE = GetName(nameof(BLUR_FEATURE));
        internal readonly static string EXAMINE_FEATURE = GetName(nameof(EXAMINE_FEATURE));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new SearchFeatureVerbType(),
                new ExamineFeatureVerbType(),
                new BlurFeatureVerbType()
            ];
    }
}
