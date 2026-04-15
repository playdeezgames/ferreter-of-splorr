namespace FOS.Model
{
    internal static class CharacterVerbs
    {
        private static string GetName(string name) => $"{nameof(CharacterVerbs)}.{name}";
        internal readonly static string BLUR_CHARACTER = GetName(nameof(BLUR_CHARACTER));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                .. GorachanVerbs.All,
                new BlurCharacterVerbType()
            ];
    }
}
