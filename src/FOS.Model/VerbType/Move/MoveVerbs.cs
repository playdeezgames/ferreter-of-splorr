namespace FOS.Model.VerbType
{
    internal static class MoveVerbs
    {
        internal readonly static string MOVE_AHEAD = nameof(MOVE_AHEAD);
        internal readonly static string CLIMB_UP = nameof(CLIMB_UP);
        internal readonly static string CLIMB_DOWN = nameof(CLIMB_DOWN);
        internal readonly static string EXIT_LOCATION = nameof(EXIT_LOCATION);
        internal readonly static string ENTER_LOCATION = nameof(ENTER_LOCATION);
        internal readonly static string USE_PORTAL = nameof(USE_PORTAL);
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new MoveAheadVerbType(),
                new ClimbUpVerbType(),
                new ClimbDownVerbType(),
                new EnterLocationVerbType(),
                new ExitLocationVerbType(),
                new UsePortalVerbType()
            ];
    }
}
