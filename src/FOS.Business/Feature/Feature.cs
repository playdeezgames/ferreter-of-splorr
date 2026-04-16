using FOS.Data;

namespace FOS.Business
{
    internal class Feature(
        WorldData data,
        IGrimoire grimoire,
        Guid featureId) :
            Entity<FeatureData>(
                data,
                grimoire),
            IFeature
    {
        public Guid FeatureId => featureId;

        public string Name => GetEntityData().Name;

        public ITrigger AppendTrigger(string triggerCategory, string triggerTypeId, Action<ITrigger>? initializer = null)
        {
            if (HasTrigger(triggerCategory))
            {
                return GetTrigger(triggerCategory).AppendTrigger(triggerTypeId, initializer);
            }
            else
            {
                var triggerId = Guid.NewGuid();
                Data.Triggers[triggerId] = new TriggerData
                {
                    TriggerType = triggerTypeId
                };
                var result = new Trigger(Data, Grimoire, triggerId);
                initializer?.Invoke(result);
                TriggerIds[triggerCategory] = result.TriggerId;
                return result;
            }
        }

        private Dictionary<string, Guid> TriggerIds => GetEntityData().TriggerIds;

        public void ClearTrigger(string triggerCategory)
        {
            TriggerIds.Remove(triggerCategory);
        }

        public ITrigger GetTrigger(string triggerCategory)
        {
            return new Trigger(Data, Grimoire, TriggerIds[triggerCategory]);
        }

        public bool HasTrigger(string triggerCategory)
        {
            return TriggerIds.ContainsKey(triggerCategory);
        }

        internal override FeatureData GetEntityData()
        {
            return Data.Features[FeatureId];
        }
    }
}
