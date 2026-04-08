namespace FOS.Business
{
    internal static class Verbs
    {
        internal readonly static string TURN_LEFT = nameof(TURN_LEFT);
        internal readonly static string TURN_RIGHT = nameof(TURN_RIGHT);
        internal readonly static string TURN_AROUND = nameof(TURN_AROUND);
        internal readonly static string MOVE_AHEAD = nameof(MOVE_AHEAD);
        internal static IReadOnlyDictionary<string, IVerbType> All =
            new List<IVerbType>
            {
                new TurnLeftVerbType(),
                new TurnRightVerbType(),
                new TurnAroundVerbType(),
                new MoveAheadVerbType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
