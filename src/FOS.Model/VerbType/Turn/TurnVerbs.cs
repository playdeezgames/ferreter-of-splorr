namespace FOS.Model
{
    internal static class TurnVerbs
    {
        private static string GetName(string name) => $"{nameof(TurnVerbs)}.{name}";
        internal readonly static string TURN_LEFT = GetName(nameof(TURN_LEFT));
        internal readonly static string TURN_RIGHT = GetName(nameof(TURN_RIGHT));
        internal readonly static string TURN_AROUND = GetName(nameof(TURN_AROUND));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new TurnLeftVerbType(),
                new TurnRightVerbType(),
                new TurnAroundVerbType()
            ];
    }
}
