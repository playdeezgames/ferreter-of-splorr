namespace FOS.Business
{
    internal static class TriggerTypes
    {
        internal static readonly string CLEAR_FEATURE_TAG = nameof(CLEAR_FEATURE_TAG);
        internal static readonly string BESTOW_INVENTORY = nameof(BESTOW_INVENTORY);
        internal static readonly string DESTROY_FEATURE_TRIGGER = nameof(DESTROY_FEATURE_TRIGGER);
        internal static readonly string ADD_MESSAGE = nameof(ADD_MESSAGE);
        internal static IReadOnlyDictionary<string, ITriggerType> All =
            new List<ITriggerType>
            {
                new ClearFeatureTagTriggerType(),
                new BestowInventoryTriggerType(),
                new DestroyFeatureTriggerTriggerType(),
                new AddMessageTriggerType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
