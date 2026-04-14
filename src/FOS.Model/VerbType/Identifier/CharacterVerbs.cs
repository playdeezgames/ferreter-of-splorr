namespace FOS.Model
{
    internal static class CharacterVerbs
    {
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new BlurCharacterVerbType()
            ];
    }
}
