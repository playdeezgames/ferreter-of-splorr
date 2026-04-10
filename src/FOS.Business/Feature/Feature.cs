using FOS.Data;

namespace FOS.Business
{
    internal class Feature(WorldData data, Guid featureId) : Entity<FeatureData>(data), IFeature
    {
        public Guid FeatureId => featureId;

        public string Name => GetEntityData().Name;

        public void ClearTrigger(string triggerCategory)
        {
            GetEntityData().TriggerIds.Remove(triggerCategory);
        }

        public void FireTrigger(string triggerCategory, ICharacter character)
        {
            if (!HasTrigger(triggerCategory))
            {
                return;
            }
            GetTrigger(triggerCategory).Fire(character);
        }

        public ITrigger GetTrigger(string triggerCategory)
        {
            return new Trigger(_data, GetEntityData().TriggerIds[triggerCategory]);
        }

        public bool HasTrigger(string triggerCategory)
        {
            return GetEntityData().TriggerIds.ContainsKey(triggerCategory);
        }

        public void SetTrigger(string triggerCategory, ITrigger trigger)
        {
            GetEntityData().TriggerIds[triggerCategory] = trigger.TriggerId;
        }

        internal override FeatureData GetEntityData()
        {
            return _data.Features[FeatureId];
        }
    }
}
