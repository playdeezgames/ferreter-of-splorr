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
                new VerbType(
                    SEARCH_FEATURE,
                    (x, _) => !x.IsDead() && (x.FocusFeature?.HasTrigger(Triggers.SEARCH) ?? false),
                    x=> "Search...",
                    (x, _)=> x.FocusFeature!.FireTrigger(Triggers.SEARCH, x)),
                new VerbType(
                    EXAMINE_FEATURE,
                    (x, _) => !x.IsDead() && (x.FocusFeature?.HasTrigger(Triggers.EXAMINE) ?? false),
                    x=>"Examine...",
                    (x, _)=> x.FocusFeature!.FireTrigger(Triggers.EXAMINE, x)),
                new VerbType(
                    BLUR_FEATURE,
                    (x, _) => !x.IsDead() && x.HasFocusFeature,
                    x=> "Features...",
                    (x, _)=> x.FocusFeature = null),
            ];
    }
}
