namespace FOS.Model
{
    internal static class TriggerTypes
    {
        private static string GetName(string name) => $"{nameof(TriggerTypes)}.{name}";
        internal static readonly string CLEAR_FEATURE_TAG = GetName(nameof(CLEAR_FEATURE_TAG));
        internal static readonly string BESTOW_INVENTORY = GetName(nameof(BESTOW_INVENTORY));
        internal static readonly string DESTROY_FEATURE_TRIGGER = GetName(nameof(DESTROY_FEATURE_TRIGGER));
        internal static readonly string ADD_MESSAGE = GetName(nameof(ADD_MESSAGE));
        internal static readonly string SPAWN_CREATURE = GetName(nameof(SPAWN_CREATURE));
        internal static IReadOnlyDictionary<string, ITriggerType> All =
            new List<ITriggerType>
            {
                new ClearFeatureTagTriggerType(),
                new BestowInventoryTriggerType(),
                new DestroyFeatureTriggerTriggerType(),
                new AddMessageTriggerType(),
                new SpawnCreatureTriggerType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
