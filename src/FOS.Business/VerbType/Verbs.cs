namespace FOS.Business
{
    internal static class Verbs
    {
        internal readonly static string TURN_LEFT = nameof(TURN_LEFT);
        internal static IReadOnlyDictionary<string, IVerbType> All =
            new List<IVerbType>
            {
                new TurnLeftVerbType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
