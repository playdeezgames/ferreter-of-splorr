namespace FOS.Business
{
    internal class DestroyFeatureTriggerTriggerType : ITriggerType
    {
        public string Identifier => TriggerTypes.DESTROY_FEATURE_TRIGGER;

        public void Fire(ITrigger trigger, ICharacter character)
        {
            character.FocusFeature!.ClearTrigger(trigger.GetMetadata(Metadatas.TRIGGER_ID));
        }
    }
}