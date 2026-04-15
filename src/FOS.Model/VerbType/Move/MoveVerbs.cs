namespace FOS.Model.VerbType
{
    internal static class MoveVerbs
    {
        private static string GetName(string name) => $"{nameof(MoveVerbs)}.{name}";
        internal readonly static string MOVE_AHEAD = GetName(nameof(MOVE_AHEAD));
        internal readonly static string CLIMB_UP = GetName(nameof(CLIMB_UP));
        internal readonly static string CLIMB_DOWN = GetName(nameof(CLIMB_DOWN));
        internal readonly static string EXIT_LOCATION = GetName(nameof(EXIT_LOCATION));
        internal readonly static string ENTER_LOCATION = GetName(nameof(ENTER_LOCATION));
        internal readonly static string USE_PORTAL = GetName(nameof(USE_PORTAL));
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
