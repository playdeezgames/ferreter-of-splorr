namespace FOS.Model
{
    internal static class ModeVerbs
    {
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
