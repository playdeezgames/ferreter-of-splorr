namespace FOS.Model
{
    internal static class CharacterVerbs
    {
        internal readonly static string BLUR_CHARACTER = nameof(BLUR_CHARACTER);
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new BlurCharacterVerbType()
            ];
    }
}
