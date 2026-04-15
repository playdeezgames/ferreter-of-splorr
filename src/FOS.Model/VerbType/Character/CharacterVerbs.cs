namespace FOS.Model
{
    internal static class CharacterVerbs
    {
        private static string GetName(string name) => $"{nameof(CharacterVerbs)}.{name}";
        private readonly static string BLUR = GetName(nameof(BLUR));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                .. GorachanVerbs.All,
                new VerbType(
                    BLUR,
                    x => x.HasFocusCharacter,
                    x => "Characters...",
                    x => x.FocusCharacter = null)
            ];
    }
}
