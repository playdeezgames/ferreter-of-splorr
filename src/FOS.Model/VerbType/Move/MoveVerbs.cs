namespace FOS.Model
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
                new MoveVerbType(
                    MoveVerbs.MOVE_AHEAD,
                    x => "Move Ahead",
                    x => x.Direction,
                    (x, r) => $"{x.Name} moves ahead thru {r.Name}.",
                    (x, r) => $"{x.Name} cannot move thru {r.Name}."),
                new MoveVerbType(
                    MoveVerbs.CLIMB_UP,
                    x => "Climb Up",
                    x => Directions.UP,
                    (x, r) => $"{x.Name} climbs up {r.Name}.",
                    (x, r) => $"{x.Name} cannot climb up {r.Name}."),
                new MoveVerbType(
                    MoveVerbs.CLIMB_DOWN,
                    x => "Climb Down",
                    x => Directions.DOWN,
                    (x, r) => $"{x.Name} climbs down {r.Name}.",
                    (x, r) => $"{x.Name} cannot climb down {r.Name}."),
                new MoveVerbType(
                    MoveVerbs.ENTER_LOCATION,
                    x => "Enter",
                    x => Directions.IN,
                    (x, r) => $"{x.Name} enters thru {r.Name}.",
                    (x, r) => $"{x.Name} cannot enter {r.Name}."),
                new MoveVerbType(
                    MoveVerbs.EXIT_LOCATION,
                    x => "Exit",
                    x => Directions.OUT,
                    (x, r) => $"{x.Name} exits thru {r.Name}.",
                    (x, r) => $"{x.Name} cannot exit thru {r.Name}."),
                new MoveVerbType(
                    MoveVerbs.USE_PORTAL,
                    x => "Use Portal",
                    x => Directions.PORTAL,
                    (x, r) => $"{x.Name} uses {r.Name}.",
                    (x, r) => $"{x.Name} cannot use {r.Name}.")
            ];
    }
}
