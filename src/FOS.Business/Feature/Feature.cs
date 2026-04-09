using FOS.Data;

namespace FOS.Business
{
    internal class Feature : Entity<FeatureData>, IFeature
    {
        private readonly WorldData _data;
        private readonly Guid _featureId;
        internal Feature(WorldData data, Guid featureId)
        {
            _data = data;
            _featureId = featureId;
        }

        public Guid FeatureId => _featureId;

        public string Name => GetEntityData().Name;

        public void ClearTrigger(string triggerType)
        {
            GetEntityData().TriggerIds.Remove(triggerType);
        }

        public void FireTrigger(string triggerType, ICharacter character)
        {
            if (!HasTrigger(triggerType))
            {
                return;
            }
            GetTrigger(triggerType).Fire(character);
        }

        public ITrigger GetTrigger(string triggerType)
        {
            return new Trigger(_data, GetEntityData().TriggerIds[triggerType]);
        }

        public bool HasTrigger(string triggerType)
        {
            return GetEntityData().TriggerIds.ContainsKey(triggerType);
        }

        public void SetTrigger(string triggerType, ITrigger trigger)
        {
            GetEntityData().TriggerIds[triggerType] = trigger.TriggerId;
        }

        internal override FeatureData GetEntityData()
        {
            return _data.Features[_featureId];
        }
    }
}
