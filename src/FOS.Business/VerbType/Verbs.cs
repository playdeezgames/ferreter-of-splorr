namespace FOS.Business
{
    internal static class Verbs
    {
        internal readonly static string TURN_LEFT = nameof(TURN_LEFT);
        internal readonly static string TURN_RIGHT = nameof(TURN_RIGHT);
        internal readonly static string TURN_AROUND = nameof(TURN_AROUND);
        internal readonly static string MOVE_AHEAD = nameof(MOVE_AHEAD);
        internal readonly static string CLIMB_UP = nameof(CLIMB_UP);
        internal readonly static string CLIMB_DOWN = nameof(CLIMB_DOWN);
        internal readonly static string EXIT_LOCATION = nameof(EXIT_LOCATION);
        internal readonly static string ENTER_LOCATION = nameof(ENTER_LOCATION);
        internal readonly static string TURN_MODE = nameof(TURN_MODE);
        internal readonly static string CANCEL_MODE = nameof(CANCEL_MODE);
        internal static IReadOnlyDictionary<string, IVerbType> All =
            new List<IVerbType>
            {
                new TurnLeftVerbType(),
                new TurnRightVerbType(),
                new TurnAroundVerbType(),
                new MoveAheadVerbType(),
                new ClimbUpVerbType(),
                new ClimbDownVerbType(),
                new EnterLocationVerbType(),
                new ExitLocationVerbType(),
                new TurnModeVerbType(),
                new CancelModeVerbType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
