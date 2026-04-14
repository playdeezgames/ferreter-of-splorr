namespace FOS.Model
{
    internal static class ModeVerbs
    {
        internal readonly static string TURN_MODE = nameof(TURN_MODE);
        internal readonly static string CANCEL_MODE = nameof(CANCEL_MODE);
        internal readonly static string MOVE_MODE = nameof(MOVE_MODE);
        internal readonly static string FEATURES_MODE = nameof(FEATURES_MODE);
        internal readonly static string INVENTORY_MODE = nameof(INVENTORY_MODE);
        internal readonly static string GROUND_INVENTORY_MODE = nameof(GROUND_INVENTORY_MODE);
        internal readonly static string CHARACTERS_MODE = nameof(CHARACTERS_MODE);
        internal readonly static string STATISTICS_MODE = nameof(STATISTICS_MODE);
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
