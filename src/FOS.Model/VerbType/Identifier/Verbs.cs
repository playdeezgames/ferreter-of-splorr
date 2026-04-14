using FOS.Model.VerbType;

namespace FOS.Model
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
        internal readonly static string USE_PORTAL = nameof(USE_PORTAL);

        internal readonly static string TURN_MODE = nameof(TURN_MODE);
        internal readonly static string CANCEL_MODE = nameof(CANCEL_MODE);
        internal readonly static string MOVE_MODE = nameof(MOVE_MODE);
        internal readonly static string FEATURES_MODE = nameof(FEATURES_MODE);
        internal readonly static string INVENTORY_MODE = nameof(INVENTORY_MODE);
        internal readonly static string GROUND_INVENTORY_MODE = nameof(GROUND_INVENTORY_MODE);
        internal readonly static string CHARACTERS_MODE = nameof(CHARACTERS_MODE);
        internal readonly static string STATISTICS_MODE = nameof(STATISTICS_MODE);

        internal readonly static string SEARCH_FEATURE = nameof(SEARCH_FEATURE);
        internal readonly static string BLUR_FEATURE = nameof(BLUR_FEATURE);
        internal readonly static string EXAMINE_FEATURE = nameof(EXAMINE_FEATURE);

        internal readonly static string BLUR_ITEM = nameof(BLUR_ITEM);
        internal readonly static string DROP_ITEM = nameof(DROP_ITEM);
        internal readonly static string TAKE_ITEM = nameof(TAKE_ITEM);

        internal readonly static string BLUR_CHARACTER = nameof(BLUR_CHARACTER);
        private static readonly IReadOnlyList<IVerbType> allVerbTypes =
            [
                .. TurnVerbs.All,
                .. MoveVerbs.All,
                .. ModeVerbs.All,
                .. ItemVerbs.All,
            ];
        internal static IReadOnlyDictionary<string, IVerbType> All =
            allVerbTypes.ToDictionary(x => x.Identifier, x => x);
    }
}
