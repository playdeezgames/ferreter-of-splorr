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
                new VerbType(
                    TURN_LEFT,
                    (x,_) => !x.IsDead() && x.HasMode() && x.GetMode() == Modes.TURN,
                    x=> "Turn Left",
                    (x,_) =>
                    {
                        x.Direction = Directions.All[x.Direction].Previous;
                        x.ClearMode();
                        x.AddMessage(Moods.NORMAL, "You turn left.");
                    }),
                new VerbType(
                    TURN_RIGHT,
                    (x,_) => !x.IsDead() && x.HasMode() && x.GetMode() == Modes.TURN,
                    x=> "Turn Right",
                    (x,_) =>
                    {
                        x.Direction = Directions.All[x.Direction].Next;
                        x.ClearMode();
                        x.AddMessage(Moods.NORMAL, "You turn right.");
                    }),
                new VerbType(
                    TURN_AROUND,
                    (x,_) => !x.IsDead() && x.HasMode() && x.GetMode() == Modes.TURN,
                    x=> "Turn Around",
                    (x,_) =>
                    {
                        x.Direction = Directions.All[x.Direction].Opposite;
                        x.ClearMode();
                        x.AddMessage(Moods.NORMAL, "You turn around.");
                    }),
            ];
    }
}
