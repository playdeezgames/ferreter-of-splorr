using FOS.Data;

namespace FOS.Business
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    internal class Feature(WorldData data, IGrimoire grimoire, Guid featureId) : Entity<FeatureData>(data, grimoire), IFeature
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
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
            return new Trigger(data, grimoire, GetEntityData().TriggerIds[triggerCategory]);
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
            return data.Features[FeatureId];
        }
    }
}
