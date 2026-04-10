namespace FOS.Business
{
    internal static class TriggerTypes
    {
        internal static readonly string CLEAR_FEATURE_TAG = nameof(CLEAR_FEATURE_TAG);
        internal static readonly string BESTOW_ITEM_OF_TYPE = nameof(BESTOW_ITEM_OF_TYPE);
        internal static readonly string DESTROY_FEATURE_TRIGGER = nameof(DESTROY_FEATURE_TRIGGER);
        internal static IReadOnlyDictionary<string, ITriggerType> All =
            new List<ITriggerType>
            {
                new ClearFeatureTagTriggerType(),
                new BestowItemOfTypeTriggerType(),
                new DestroyFeatureTriggerTriggerType()
            }.ToDictionary(x => x.Identifier, x => x);
    }
}
