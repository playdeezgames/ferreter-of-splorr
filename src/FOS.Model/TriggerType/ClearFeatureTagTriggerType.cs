using FOS.Business;

namespace FOS.Model
{
    internal class ClearFeatureTagTriggerType : ITriggerType
    {
        public string Identifier => TriggerTypes.CLEAR_FEATURE_TAG;

        public void Fire(ITrigger trigger, ICharacter character)
        {
            var feature = character.FocusFeature!;
            var tagId = trigger.GetMetadata(Metadatas.TAG_ID);
            feature.ClearTag(tagId);
        }
    }
}