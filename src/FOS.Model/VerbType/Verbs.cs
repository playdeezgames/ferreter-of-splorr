namespace FOS.Model
{
    internal static class Verbs
    {
        private static readonly IReadOnlyList<IVerbType> allVerbTypes =
            [
                .. TurnVerbs.All,
                .. MoveVerbs.All,
                .. ModeVerbs.All,
                .. ItemVerbs.All,
                .. LocationVerbs.All,
                .. FeatureVerbs.All,
                .. CharacterVerbs.All,
            ];
        internal static IReadOnlyDictionary<string, IVerbType> All =
            allVerbTypes.ToDictionary(x => x.Identifier, x => x);
    }
}
