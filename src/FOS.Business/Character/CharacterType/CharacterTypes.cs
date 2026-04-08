namespace FOS.Business
{
    internal static class CharacterTypes
    {
        internal readonly static string N00B = nameof(N00B);
        internal readonly static IReadOnlyDictionary<string, ICharacterType> All =
            new List<ICharacterType> { new N00bCharacterType() }.ToDictionary(x => x.Identifier, x => x);
    }
}
