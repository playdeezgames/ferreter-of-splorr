namespace FOS.Model
{
    internal static class ModeVerbs
    {
        private static string GetName(string name) => $"{nameof(ModeVerbs)}.{name}";
        internal readonly static string TURN_MODE = GetName(nameof(TURN_MODE));
        internal readonly static string CANCEL_MODE = GetName(nameof(CANCEL_MODE));
        internal readonly static string MOVE_MODE = GetName(nameof(MOVE_MODE));
        internal readonly static string FEATURES_MODE = GetName(nameof(FEATURES_MODE));
        internal readonly static string INVENTORY_MODE = GetName(nameof(INVENTORY_MODE));
        internal readonly static string GROUND_INVENTORY_MODE = GetName(nameof(GROUND_INVENTORY_MODE));
        internal readonly static string CHARACTERS_MODE = GetName(nameof(CHARACTERS_MODE));
        internal readonly static string STATISTICS_MODE = GetName(nameof(STATISTICS_MODE));
        private static readonly Dictionary<string, string> cancelVerbTexts =
            new()
            {
                [Modes.TURN] = "Don't Turn",
                [Modes.STATISTICS] = "Leave Statistics",
                [Modes.GROUND_INVENTORY] = "Leave Ground Inventory",
                [Modes.INVENTORY] = "Leave Inventory",
                [Modes.CHARACTERS] = "Disengage Characters",
                [Modes.MOVE] = "Don't Move",
                [Modes.FEATURES] = "Disengage Features"
            };
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new VerbType(
                    TURN_MODE,
                    (x,_)=> !x.IsDead() && !x.HasMode(),
                    x=> "Turn...",
                    (x,_)=> x.SetMode(Modes.TURN)),
                new VerbType(
                    CANCEL_MODE,
                    (x,_)=> !x.IsDead() &&
                x.HasMode() &&
                (
                    x.GetMode() == Modes.TURN ||
                    x.GetMode() == Modes.STATISTICS ||
                    (x.GetMode() == Modes.GROUND_INVENTORY && !x.HasFocusItem) ||
                    (x.GetMode() == Modes.INVENTORY && !x.HasFocusItem) ||
                    (x.GetMode() == Modes.CHARACTERS && !x.HasFocusCharacter) ||
                    x.GetMode() == Modes.MOVE ||
                    (x.GetMode() == Modes.FEATURES && !x.HasFocusFeature)),
                    x=>cancelVerbTexts![x.GetMode()],
                    (x,_)=>x.ClearMode()),
                new VerbType(
                    MOVE_MODE,
                    (x,_)=>!x.IsDead() && !x.HasMode(),
                    x=>"Move...",
                    (x,_)=>x.SetMode(Modes.MOVE)),
                new VerbType(
                    FEATURES_MODE,
                    (x,_)=>!x.IsDead() && !x.HasMode() && x.Location.HasFeatures,
                    x=>"Features...",
                    (x,_)=>x.SetMode(Modes.FEATURES)),
                new VerbType(
                    INVENTORY_MODE,
                    (x,_)=>!x.IsDead() && !x.HasMode() && x.Inventory.HasItems,
                    x=>"Inventory...",
                    (x,_)=>x.SetMode(Modes.INVENTORY)),
                new VerbType(
                    GROUND_INVENTORY_MODE,
                    (x,_)=>!x.IsDead() && !x.HasMode() && x.Location.Inventory.HasItems,
                    x=>"Ground...",
                    (x,_)=>x.SetMode(Modes.GROUND_INVENTORY)),
                new VerbType(
                    CHARACTERS_MODE,
                    (x,_)=>!x.IsDead() && !x.HasMode() && x.Location.HasOtherCharacters(x),
                    x=>"Characters...",
                    (x,_)=>x.SetMode(Modes.CHARACTERS)),
                new VerbType(
                    STATISTICS_MODE,
                    (x,_)=>!x.HasMode(),
                    x=>"Statistics...",
                    (x,_)=>x.SetMode(Modes.STATISTICS))
            ];
    }
}
