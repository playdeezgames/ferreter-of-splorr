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
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new CancelModeVerbType(),
                new TurnModeVerbType(),
                new MoveModeVerbType(),
                new FeaturesModeVerbType(),
                new InventoryModeVerbType(),
                new GroundInventoryModeVerbType(),
                new CharactersModeVerbType(),
                new StatisticsModeVerbType()
            ];
    }
}
