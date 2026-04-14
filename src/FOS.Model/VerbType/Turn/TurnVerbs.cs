namespace FOS.Model.VerbType
{
    internal static class TurnVerbs
    {
        internal readonly static string TURN_LEFT = nameof(TURN_LEFT);
        internal readonly static string TURN_RIGHT = nameof(TURN_RIGHT);
        internal readonly static string TURN_AROUND = nameof(TURN_AROUND);
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new TurnLeftVerbType(),
                new TurnRightVerbType(),
                new TurnAroundVerbType()
            ];
    }
}
